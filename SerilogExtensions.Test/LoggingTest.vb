Imports Brandgroup.SerilogExtensions.Enrichers
Imports Serilog
Imports Xunit
Imports Brandgroup.SerilogExtensions.SerilogExtensions
Imports Brandgroup.SerilogExtensions.Sinks.MySql

Public Class LoggingTest

    <Fact>
    Sub SqlTestSub()
        Log.Logger = New LoggerConfiguration() _
                .Enrich.With(New BrandgroupEnricher()) _
                .WriteTo.MySql("Server=srvfbmysql;Database=verwaltung;Uid=root;Pwd=rootpb292;", "LogsTest") _
                .CreateLogger()

        BLogInformation("Hallo .NET 8")
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