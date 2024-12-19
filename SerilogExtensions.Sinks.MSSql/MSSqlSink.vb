Imports Microsoft.Data.SqlClient
#If NETSTANDARD2_0_OR_GREATER Then
Imports System.Text.Json
#Else
Imports Newtonsoft.Json
#End If
Imports Serilog
Imports Serilog.Configuration
Imports Serilog.Core
Imports Serilog.Events
Imports Serilog.Filters
Imports System.Data



''' <summary>
''' Serilog Sink that writes log events to a Microsoft SQL Server Database
''' </summary>
Public Class MSSqlSink
    Implements ILogEventSink


    Private ReadOnly _connectionString As String
    Private ReadOnly _tableName As String



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="connectionString"></param>
    ''' <param name="tableName"></param>
    Public Sub New(connectionString As String, tableName As String)
        _connectionString = connectionString
        _tableName = tableName
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="logEvent"></param>
    Public Sub Emit(logEvent As LogEvent) Implements ILogEventSink.Emit
        If logEvent Is Nothing Then Throw New ArgumentNullException(NameOf(logEvent))

        Using connection As New SqlConnection(_connectionString)
            connection.Open()

            Dim command As New SqlCommand($"INSERT INTO {_tableName} (Timestamp_UTC, Level, Message, MessageTemplate, Exception, Properties, Program, [User], Ip, HostName, [Function]) VALUES (@Timestamp, @Level, @Message, @MessageTemplate, @Exception, @Properties, @Program, @User, @Ip, @HostName, @Function)", connection)
            command.Parameters.AddWithValue("@Timestamp", logEvent.Timestamp.UtcDateTime)
            command.Parameters.AddWithValue("@Level", logEvent.Level.ToString())
            command.Parameters.AddWithValue("@Message", logEvent.RenderMessage())
            command.Parameters.AddWithValue("@MessageTemplate", logEvent.MessageTemplate.Text)
            If logEvent.Exception IsNot Nothing Then
                command.Parameters.AddWithValue("@Exception", logEvent.Exception.ToString())
            Else
                command.Parameters.AddWithValue("@Exception", DBNull.Value)
            End If
            command.Parameters.AddWithValue("@Properties", SerializeProperties(logEvent))

            Dim processName = GetPropertyValue(logEvent, "ProcessName")
            command.Parameters.AddWithValue("@Program", processName)
            command.Parameters.AddWithValue("@User", GetPropertyValue(logEvent, "Username"))
            command.Parameters.AddWithValue("@Ip", GetPropertyValue(logEvent, "LocalIpv4"))
            command.Parameters.AddWithValue("@HostName", GetPropertyValue(logEvent, "DnsHostName"))
            command.Parameters.AddWithValue("@Function", GetPropertyValue(logEvent, "MemberName"))

            ' Debug
            'Dim debugCommand = GetQueryWithParameters(command)

            command.ExecuteNonQuery()
        End Using
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="logEvent"></param>
    ''' <returns></returns>
    Private Function SerializeProperties(logEvent As LogEvent) As String

        Dim dict As Dictionary(Of String, Object) =
                logEvent.Properties _
                .ToDictionary(Of String, Object)(Function(kvp) kvp.Key, Function(kvp) kvp.Value.ToString())

#If NETSTANDARD2_0_OR_GREATER Then
        Return JsonSerializer.Serialize(dict)
#Else
        Return JsonConvert.SerializeObject(dict)
#End If
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="logEvent"></param>
    ''' <param name="propertyName"></param>
    ''' <returns></returns>
    Private Function GetPropertyValue(logEvent As LogEvent, propertyName As String) As String
        If logEvent.Properties.ContainsKey(propertyName) Then
            Dim prop = logEvent.Properties(propertyName)
            Dim propScalarVal = TryCast(prop, ScalarValue)

            If propScalarVal Is Nothing Then Return Nothing

            Return propScalarVal.Value.ToString()
        End If

        Return Nothing
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="command"></param>
    ''' <returns></returns>
    Public Function GetQueryWithParameters(command As SqlCommand) As String
        Dim query As String = command.CommandText

        For Each parameter As SqlParameter In command.Parameters
            Dim parameterValue As String

            If parameter.Value Is Nothing OrElse parameter.Value Is DBNull.Value Then
                parameterValue = "NULL"
            ElseIf parameter.SqlDbType = SqlDbType.VarChar OrElse
                   parameter.SqlDbType = SqlDbType.NVarChar OrElse
                   parameter.SqlDbType = SqlDbType.Char OrElse
                   parameter.SqlDbType = SqlDbType.NChar OrElse
                   parameter.SqlDbType = SqlDbType.Text OrElse
                   parameter.SqlDbType = SqlDbType.NText OrElse
                   parameter.SqlDbType = SqlDbType.Date OrElse
                   parameter.SqlDbType = SqlDbType.DateTime OrElse
                   parameter.SqlDbType = SqlDbType.DateTime2 OrElse
                   parameter.SqlDbType = SqlDbType.UniqueIdentifier Then
                ' Add single quotes for string and date/time types, escape single quotes
                parameterValue = $"'{parameter.Value.ToString().Replace("'", "''")}'"
            Else
                ' Use raw value for numeric types
                parameterValue = parameter.Value.ToString()
            End If

            ' Replace parameter placeholder in query
            query = query.Replace(parameter.ParameterName, parameterValue)
        Next

        Return query
    End Function

End Class



''' <summary>
''' 
''' </summary>
Public Module MSSqlSinkExtensions



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="loggerConfiguration"></param>
    ''' <param name="connectionString"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function MSSql(loggerConfiguration As LoggerSinkConfiguration, connectionString As String, tableName As String) As LoggerConfiguration
        Return loggerConfiguration.Logger(Sub(lc)
                                              lc.Filter.ByExcluding(Matching.WithProperty("NoMSSql", True))
                                              lc.WriteTo.Sink(New MSSqlSink(connectionString, tableName))
                                          End Sub)
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="loggerConfiguration"></param>
    ''' <param name="connectionString"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function BrandMSSql(loggerConfiguration As LoggerSinkConfiguration, connectionString As String, tableName As String) As LoggerConfiguration
        Return loggerConfiguration.MSSql(connectionString, tableName)
    End Function
End Module