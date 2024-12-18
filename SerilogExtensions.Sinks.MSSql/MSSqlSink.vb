Imports Serilog.Core
Imports Serilog.Events

Public Class MSSqlSink
    Implements ILogEventSink

    Public Sub Emit(logEvent As LogEvent) Implements ILogEventSink.Emit
        Throw New NotImplementedException
    End Sub
End Class
