Imports System.Net
Imports Serilog.Core
Imports Serilog.Events

Namespace Enrichers

    Public Class BrandgroupEnricher
        Implements ILogEventEnricher



#Region "Fields"
        Private _environment As Boolean
        Private _process As Boolean
        Private _network As Boolean
#End Region

        ''' <summary>
        ''' 
        ''' </summary>
        Public Sub New(Optional environment As Boolean = True, Optional process As Boolean = True, Optional network As Boolean = True)
            _environment = environment
            _process = process
            _network = network
        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="logEvent"></param>
        ''' <param name="propertyFactory"></param>
        Public Sub Enrich(logEvent As LogEvent, propertyFactory As ILogEventPropertyFactory) Implements ILogEventEnricher.Enrich
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("NoMySql", False))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("NoFile", False))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("NoMSSql", False))

            If _environment Then
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Environment.CurrentManagedThreadId))
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Username", Environment.UserName))
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("PcName", Environment.MachineName))
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("OSVersion", Environment.OSVersion.VersionString))
            End If

            If _process Then
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ProcessName", Process.GetCurrentProcess().ProcessName))
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("BaseDirectory", AppContext.BaseDirectory))
            End If

            If _network Then
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("DnsHostName", Dns.GetHostName()))

                Dim ip = "0"
#If NET46 Then

#ElseIf NETSTANDARD2_0 Then
                Dim ips = NetworkUtils.GetAllIpAddresses()
                If ips.Any() Then ip = ips.First()
#End If
                    logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("LocalIpv4", ip))
                End If

            ' TODO Funktionsname
        End Sub
    End Class
End Namespace