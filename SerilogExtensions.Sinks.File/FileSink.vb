Imports Serilog
Imports Serilog.Configuration
Imports Serilog.Core
Imports Serilog.Events
Imports Serilog.Filters



Public Class FileSink
    Implements ILogEventSink


    Private _path As String
    Private _rollingInterval As RollingInterval
    Private _outputTemplate As String


    Public Sub New(path As String, rollingInterval As RollingInterval, outputTemplate As String)
        _path = path
        _rollingInterval = rollingInterval
        _outputTemplate = outputTemplate
    End Sub


    Public Sub Emit(logEvent As LogEvent) Implements ILogEventSink.Emit

    End Sub



End Class



Public Module FileSinkExtensions



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function GetBrandgroupTemplate() As String
        Return "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="loggerConfiguration"></param>
    ''' <param name="filePath">Path to the file.</param>
    ''' <param name="rollingInterval"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension()>
    Public Function File(loggerConfiguration As LoggerSinkConfiguration, filePath As String, Optional rollingInterval As RollingInterval = RollingInterval.Infinite) As LoggerConfiguration

        Return loggerConfiguration.Logger(Sub(lc)
                                              lc.Filter.ByExcluding(Matching.WithProperty("NoFile", True))
                                              lc.WriteTo.File(filePath, rollingInterval:=rollingInterval, outputTemplate:=GetBrandgroupTemplate())
                                          End Sub)
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="loggerConfiguration"></param>
    ''' <param name="filePath">Path to the file.</param>
    ''' <param name="rollingInterval"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension()>
    Public Function BrandFile(loggerConfiguration As LoggerSinkConfiguration, filePath As String, Optional rollingInterval As RollingInterval = RollingInterval.Infinite) As LoggerConfiguration
        Return loggerConfiguration.File(filePath, rollingInterval)
    End Function

End Module
