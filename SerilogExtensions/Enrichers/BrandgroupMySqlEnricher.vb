Imports System
Imports System.Net
Imports Serilog.Core
Imports Serilog.Events

Namespace Brandgroup.SerilogExtensions.Enrichers
    Public Class BrandgroupMySqlEnricher
        Implements ILogEventEnricher

        Public Sub Enrich(logEvent As LogEvent, propertyFactory As ILogEventPropertyFactory) Implements ILogEventEnricher.Enrich
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Program", GetProgramName()))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("User", Environment.UserName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Ip", GetLocalIPAddress()))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("HostName", Environment.MachineName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Function", GetCallingMethodName()))
        End Sub

        Private Function GetProgramName() As String
            Return System.AppDomain.CurrentDomain.FriendlyName
        End Function

        Private Function GetLocalIPAddress() As String
            Dim host As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
            For Each ip As IPAddress In host.AddressList
                If ip.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "IP Address nicht vorhanden"
        End Function

        Private Function GetCallingMethodName() As String
            Dim st = New StackTrace()
            Dim frames = st.GetFrames()
            For i As Integer = 3 To frames.Length - 1
                Dim method = frames(i).GetMethod()
                If method.DeclaringType.Namespace IsNot Nothing AndAlso
                   Not method.DeclaringType.Namespace.StartsWith("System") AndAlso
                   Not method.DeclaringType.Namespace.StartsWith("Serilog") Then
                    Return $"{method.DeclaringType.FullName}.{method.Name}"
                End If
            Next
            Return "Unknown Method"
        End Function

    End Class


End Namespace