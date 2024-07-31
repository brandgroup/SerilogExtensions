Imports System.Net
Imports Serilog.Core
Imports Serilog.Events
#Disable Warning UnusedImportClause
Imports Roslan.DotNetUtils.Net
#Enable Warning UnusedImportClause

Namespace Enrichers

    Public Class BrandgroupEnricher
        Implements ILogEventEnricher



        ''' <summary>
        ''' 
        ''' </summary>
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
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Username", Environment.UserName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("DnsHostName", Dns.GetHostName()))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("PcName", Environment.MachineName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("OSVersion", Environment.OSVersion.VersionString))
            Dim ip = "0"
#If NET46 Then

#ElseIf NETSTANDARD2_0 Then
            Dim ips As IList(Of String) = NetworkUtils.GetAllIpAddresses()
            If ips.Count > 0 Then ip = ips(0)
#End If
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("LocalIpv4", ip))
            ' TODO Funktionsname
        End Sub
    End Class
End Namespace