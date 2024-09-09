Imports Serilog
Imports Serilog.Configuration

Public Module SerilogExtensions



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
    Public Sub BLogError(Of T0, T1, T2)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, Optional propertyValue2 As T2 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Error(messageTemplate, propertyValue0, propertyValue1, propertyValue2)
    End Sub



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
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="exception">Die Exception, die aufgetreten ist.</param>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(Of T0, T1, T2)(exception As Exception, messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, Optional propertyValue2 As T2 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Error(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="exception">Die Exception, die aufgetreten ist.</param>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(exception As Exception, messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Error(exception, messageTemplate)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(Of T0, T1, T2)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, Optional propertyValue2 As T2 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Information(messageTemplate, propertyValue0, propertyValue1, propertyValue2)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(Of T0, T1)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Information(messageTemplate, propertyValue0, propertyValue1)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(Of T0)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Information(messageTemplate, propertyValue0)
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
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Warning-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogWarning(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Warning(messageTemplate)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Verbose-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogVerbose(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Verbose(messageTemplate)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Debug-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogDebug(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Debug(messageTemplate)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Fatal-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogFatal(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Fatal(messageTemplate)
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
