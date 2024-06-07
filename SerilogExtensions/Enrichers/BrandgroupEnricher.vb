Imports System.Net
Imports System.Threading
Imports Serilog.Core
Imports Serilog.Events

Namespace Enrichers

    Public Class BrandgroupEnricher
        Implements ILogEventEnricher

        Public Sub New()

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="logEvent"></param>
        ''' <param name="propertyFactory"></param>
        Public Sub Enrich(logEvent As LogEvent, propertyFactory As ILogEventPropertyFactory) Implements ILogEventEnricher.Enrich
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Environment.CurrentManagedThreadId))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ProcessName", Process.GetCurrentProcess().ProcessName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", Environment.UserName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("DnsHostName", Dns.GetHostName()))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineName", Environment.MachineName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("OSVersion", Environment.OSVersion.VersionString))
        End Sub
    End Class
End Namespace