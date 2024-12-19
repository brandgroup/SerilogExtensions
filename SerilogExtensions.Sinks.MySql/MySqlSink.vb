Imports MySql.Data.MySqlClient
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



''' <summary>
''' Serilog Sink that writes log events to a MySQL Database
''' </summary>
Public Class MySqlSink
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
    ''' Writes a LogEvent to the MySQL Database
    ''' </summary>
    ''' <param name="logEvent"></param>
    Public Sub Emit(logEvent As LogEvent) Implements ILogEventSink.Emit
        If logEvent Is Nothing Then Throw New ArgumentNullException(NameOf(logEvent))

        Using connection As New MySqlConnection(_connectionString)
            connection.Open()

            Dim command As New MySqlCommand($"INSERT INTO {_tableName} (Timestamp_UTC, Level, Message, MessageTemplate, Exception, Properties, Program, User, Ip, HostName, Function) VALUES (@Timestamp, @Level, @Message, @MessageTemplate, @Exception, @Properties, @Program, @User, @Ip, @HostName, @Function)", connection)
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
End Class



''' <summary>
''' Erweiterungsmodul für  Integration des benutzerdefinierten Sinks
''' </summary>
Public Module MySqlSinkExtensions



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="loggerConfiguration"></param>
    ''' <param name="connectionString"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension()>
    Public Function MySql(loggerConfiguration As LoggerSinkConfiguration, connectionString As String, tableName As String) As LoggerConfiguration

        Return loggerConfiguration.Logger(Sub(lc)
                                              lc.Filter.ByExcluding(Matching.WithProperty("NoMySql", True))
                                              lc.WriteTo.Sink(New MySqlSink(connectionString, tableName))
                                          End Sub)
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="loggerConfiguration"></param>
    ''' <param name="connectionString"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension()>
    Public Function BrandMySql(loggerConfiguration As LoggerSinkConfiguration, connectionString As String, tableName As String) As LoggerConfiguration
        Return loggerConfiguration.MySql(connectionString, tableName)
    End Function

End Module