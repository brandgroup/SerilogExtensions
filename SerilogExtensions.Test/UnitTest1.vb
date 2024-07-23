Imports Brandgroup.SerilogExtensions.Enrichers
Imports Serilog
Imports Xunit
Imports Brandgroup.SerilogExtensions.SerilogExtensions
Imports Brandgroup.SerilogExtensions.Sinks.Brandgroup.SerilogExtensions.Sinks
Imports System.Net
Imports Serilog.Context
Imports Brandgroup.SerilogExtensions.Brandgroup.SerilogExtensions.Enrichers

Public Class UnitTest1
    Private Const ConnectionString As String = "Server=srvfbmysql;Database=verwaltung;Uid=robert;Pwd=robert2024!;"
    Private Const TableName As String = "LogsTest"

    <Fact>
    Sub SqlTestSub()
        Log.Logger = New LoggerConfiguration() _
                .Enrich.With(New BrandgroupMySqlEnricher()) _
                .WriteTo.MySqlExtensions(ConnectionString, TableName) _
                .CreateLogger()
        Log.Information("Test")
        Log.CloseAndFlush()
    End Sub

    <Fact>
    Sub TestSub()
        Log.Logger = New LoggerConfiguration() _
            .Enrich.With(New BrandgroupEnricher()) _
            .WriteTo.File("log.txt", rollingInterval:=RollingInterval.Day, outputTemplate:=GetBrandgroupTemplate()) _
            .CreateLogger()
        BLogError("Test")
    End Sub
End Class