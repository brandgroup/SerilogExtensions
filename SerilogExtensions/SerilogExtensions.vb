﻿Public Module SerilogExtensions



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function GetBrandgroupTemplate() As String
        Return "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    End Function



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Error(messageTemplate)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Information(messageTemplate)
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="memberName"></param>
    ''' <returns></returns>
    Private Function GetBrandLogger(memberName As String) As Serilog.ILogger
        Return Serilog.Log _
            .ForContext("MemberName", memberName)
    End Function

End Module
