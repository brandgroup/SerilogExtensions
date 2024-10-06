Imports Brandgroup.SerilogExtensions2.Enrichers
Imports Brandgroup.SerilogExtensions2
Imports Brandgroup.SerilogExtensions2.Sinks.File
Imports Brandgroup.SerilogExtensions2.Sinks.MySql
Imports Serilog



<TestClass()>
Public Class UnitTest1

    <TestMethod()>
    Public Sub MySqlTest()

        Serilog.Log.Logger = New LoggerConfiguration() _
            .Enrich.With(New BrandgroupEnricher()) _
            .WriteTo.BrandMySql("server=srvfbmysql;database=verwaltung;Uid=root;Pwd=rootpb292;", "LogsTest") _
            .WriteTo.BrandFile("test.txt", rollingInterval:=RollingInterval.Day) _
        .CreateLogger()

        BLogError("Hallo .NET 4.6")
    End Sub

End Class