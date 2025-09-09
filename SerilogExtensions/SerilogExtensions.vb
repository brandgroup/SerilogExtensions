Imports Serilog.Context
Imports Serilog.Events

Public Module SerilogExtensions



#Region "Error"
    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(Of T0, T1, T2)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, Optional propertyValue2 As T2 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Error, messageTemplate, propertyValue0, propertyValue1, propertyValue2, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Error, messageTemplate, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="exception">Die Exception, die aufgetreten ist.</param>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(Of T0, T1, T2)(exception As Exception, messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, Optional propertyValue2 As T2 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Error-Level.
    ''' </summary>
    ''' <param name="exception">Die Exception, die aufgetreten ist.</param>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogError(exception As Exception, messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Error, exception, messageTemplate, memberName)
    End Sub
#End Region

#Region "Information"
    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(Of T0, T1, T2)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, Optional propertyValue2 As T2 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Information, messageTemplate, propertyValue0, propertyValue1, propertyValue2, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(Of T0, T1)(messageTemplate As String, Optional propertyValue0 As T0 = Nothing, Optional propertyValue1 As T1 = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Information, messageTemplate, propertyValue0, propertyValue1, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(Of T)(messageTemplate As String, Optional propertyValue As T = Nothing, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Information, messageTemplate, propertyValue, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Information, messageTemplate, memberName)
    End Sub



    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Information-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogInformation(messageTemplate As String, propertyValues As Object(), <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Information, messageTemplate, propertyValues, memberName)
    End Sub
#End Region

#Region "Warning"
    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Warning-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogWarning(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Warning(messageTemplate)
    End Sub
#End Region

#Region "Verbose"
    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Verbose-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogVerbose(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Verbose(messageTemplate)
    End Sub
#End Region

#Region "Debug"
    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Debug-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogDebug(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        BLogWrite(LogEventLevel.Information, messageTemplate, memberName)
    End Sub
#End Region

#Region "Fatal"
    ''' <summary>
    ''' Schreibt ein Serilog Logereignis in der brandgroup-Formatierung mit Fatal-Level.
    ''' </summary>
    ''' <param name="messageTemplate">Die Nachricht, die geloggt werden soll.</param>
    ''' <param name="memberName"></param>
    Public Sub BLogFatal(messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        GetBrandLogger(memberName) _
            .Fatal(messageTemplate)
    End Sub
#End Region

#Region "Write"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(level As LogEventLevel, exception As Exception, messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, exception, messageTemplate)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(level As LogEventLevel, exception As Exception, messageTemplate As String, propertyValues As Object(), <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, exception, messageTemplate, propertyValues)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(Of T)(level As LogEventLevel, exception As Exception, messageTemplate As String, propertyValue As T, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, exception, messageTemplate, propertyValue)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(Of T0, T1)(level As LogEventLevel, exception As Exception, messageTemplate As String, propertyValue0 As T0, propertyValue1 As T1, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, exception, messageTemplate, propertyValue0, propertyValue1)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(Of T0, T1, T2)(level As LogEventLevel, exception As Exception, messageTemplate As String, propertyValue0 As T0, propertyValue1 As T1, propertyValue2 As T2, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(level As LogEventLevel, messageTemplate As String, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, messageTemplate)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(level As LogEventLevel, messageTemplate As String, propertyValues As Object(), <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, messageTemplate, propertyValues)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(Of T)(level As LogEventLevel, messageTemplate As String, propertyValue As T, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, messageTemplate, propertyValue)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(Of T0, T1)(level As LogEventLevel, messageTemplate As String, propertyValue0 As T0, propertyValue1 As T1, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, messageTemplate, propertyValue0, propertyValue1)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="level"></param>
    ''' <param name="messageTemplate"></param>
    ''' <param name="memberName"></param>
    Public Sub BLogWrite(Of T0, T1, T2)(level As LogEventLevel, messageTemplate As String, propertyValue0 As T0, propertyValue1 As T1, propertyValue2 As T2, <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing)
        Dim logger = GetBrandLogger(memberName)

        Dim logContexts = ProcessSinkExclusions(messageTemplate)

        Using LogContext.PushProperty("MemberName", memberName)
            logger.Write(level, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
        End Using

        For Each logContext In logContexts
            logContext.Dispose()
        Next
    End Sub
#End Region



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="messageTemplate"></param>
    ''' <returns></returns>
    Private Function ProcessSinkExclusions(ByRef messageTemplate As String) As List(Of IDisposable)
        Dim result As New List(Of IDisposable)

        If messageTemplate.Contains("{NoMSSql}") Then
            messageTemplate = messageTemplate.Replace("{NoMSSql}", "")
            result.Insert(0, LogContext.PushProperty("NoMSSql", True))
        End If

        If messageTemplate.Contains("{NoMySql}") Then
            messageTemplate = messageTemplate.Replace("{NoMySql}", "")
            result.Insert(0, LogContext.PushProperty("NoMySql", True))
        End If

        If messageTemplate.Contains("{NoFile}") Then
            messageTemplate = messageTemplate.Replace("{NoFile}", "")
            result.Insert(0, LogContext.PushProperty("NoFile", True))
        End If

        Return result
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="memberName"></param>
    ''' <returns></returns>
    Private Function GetBrandLogger(memberName As String) As Serilog.ILogger
        Return Serilog.Log.Logger
    End Function


End Module
