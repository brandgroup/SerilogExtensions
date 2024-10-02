Imports Brandgroup.SerilogExtensions2.Enrichers
Imports Serilog
Imports Xunit
Imports Brandgroup.SerilogExtensions2.SerilogExtensions
Imports Brandgroup.SerilogExtensions2.Sinks.MySql

Public Class LoggingTest

    <Fact>
    Sub SqlTestSub()
        Log.Logger = New LoggerConfiguration() _
                .Enrich.With(New BrandgroupEnricher()) _
                .Enrich.FromLogContext() _
                .WriteTo.MySql("Server=srvfbmysql;Database=verwaltung;Uid=root;Pwd=rootpb292;", "logstest") _
                .CreateLogger()

        BLogInformation("Hallo .NET 8 (Kein MySQL)")
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