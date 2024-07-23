Imports MySql.Data.MySqlClient
Imports Serilog
Imports Serilog.Configuration
Imports Serilog.Core
Imports Serilog.Events
Imports Newtonsoft.Json

Namespace Brandgroup.SerilogExtensions.Sinks
    Public Class MySqlSink
        Implements ILogEventSink

        ' Private Felder für Verbindungszeichenfolge und Tabellenname
        Private ReadOnly _connectionString As String
        Private ReadOnly _tableName As String

        ' Konstruktor: Initialisiert den Sink mit Verbindungszeichenfolge und Tabellenname
        Public Sub New(connectionString As String, tableName As String)
            _connectionString = connectionString
            _tableName = tableName
        End Sub

        ' Emit-Methode: Wird für jedes Log-Ereignis aufgerufen
        Public Sub Emit(logEvent As LogEvent) Implements ILogEventSink.Emit
            ' Prüfen, ob das logEvent nicht null ist
            If logEvent Is Nothing Then
                Throw New ArgumentNullException(NameOf(logEvent))
            End If

            ' Verbindung zur MySQL-Datenbank herstellen und Log-Eintrag einfügen
            Using connection As New MySqlConnection(_connectionString)
                connection.Open()

                ' SQL-Befehl zum Einfügen des Log-Eintrags erstellen
                Dim command As New MySqlCommand($"INSERT INTO {_tableName} (Timestamp, Level, Message, MessageTemplate, Exception, Properties, Program, User, Ip, HostName, Function) VALUES (@Timestamp, @Level, @Message, @MessageTemplate, @Exception, @Properties, @Program, @User, @Ip, @HostName, @Function)", connection)

                ' Parameter zum SQL-Befehl hinzufügen
                command.Parameters.AddWithValue("@Timestamp", logEvent.Timestamp)
                command.Parameters.AddWithValue("@Level", logEvent.Level.ToString())
                command.Parameters.AddWithValue("@Message", logEvent.RenderMessage())
                command.Parameters.AddWithValue("@MessageTemplate", logEvent.MessageTemplate.Text)
                If logEvent.Exception IsNot Nothing Then
                    command.Parameters.AddWithValue("@Exception", logEvent.Exception.ToString())
                Else
                    command.Parameters.AddWithValue("@Exception", DBNull.Value)
                End If
                command.Parameters.AddWithValue("@Properties", SerializeProperties(logEvent.Properties))
                command.Parameters.AddWithValue("@Program", GetPropertyValue(logEvent, "Program"))
                command.Parameters.AddWithValue("@User", GetPropertyValue(logEvent, "User"))
                command.Parameters.AddWithValue("@Ip", GetPropertyValue(logEvent, "Ip"))
                command.Parameters.AddWithValue("@HostName", GetPropertyValue(logEvent, "HostName"))
                command.Parameters.AddWithValue("@Function", GetBrandLogger(""))
                command.ExecuteNonQuery()
            End Using
        End Sub


        Private Function GetBrandLogger(memberName As String) As Serilog.ILogger
            Return Serilog.Log _
            .ForContext("MemberName", memberName)
        End Function
        'Serialisieren der Properties
        Private Function SerializeProperties(properties As IReadOnlyDictionary(Of String, LogEventPropertyValue)) As String
            Dim dict As New Dictionary(Of String, Object)
            For Each kvp In properties
                dict.Add(kvp.Key, kvp.Value.ToString())
            Next
            Return JsonConvert.SerializeObject(dict)
        End Function

        '  Abrufen eines bestimmten Property-Werts
        Private Function GetPropertyValue(logEvent As LogEvent, propertyName As String) As String
            If logEvent.Properties.ContainsKey(propertyName) Then
                Return logEvent.Properties(propertyName).ToString()
            End If
            Return String.Empty

        End Function
    End Class

    ' Erweiterungsmodul für einfache Integration des benutzerdefinierten Sinks
    Public Module MySqlSinkExtensions
        ' Erweiterungsmethode für LoggerSinkConfiguration
        <Runtime.CompilerServices.Extension()>
        Public Function MySqlExtensions(loggerConfiguration As LoggerSinkConfiguration, connectionString As String, tableName As String) As LoggerConfiguration
            ' Erstellt eine neue Instanz des CustomMySqlSink und fügt sie zur Konfiguration hinzu
            Return loggerConfiguration.Sink(New MySqlSink(connectionString, tableName))
        End Function
    End Module


End Namespace