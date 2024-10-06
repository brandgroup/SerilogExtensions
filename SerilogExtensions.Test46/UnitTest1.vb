Imports Brandgroup.SerilogExtensions2.Enrichers
Imports Brandgroup.SerilogExtensions2.Sinks.MySql
Imports Brandgroup.SerilogExtensions2.Sinks.File

Imports Serilog

<TestClass()>
Public Class UnitTest1

    <TestMethod()>
    Public Sub MySqlTest()

        Serilog.Log.Logger = New LoggerConfiguration() _
            .Enrich.With(New BrandgroupEnricher()) _
            .WriteTo.MySql("server=srvfbmysql;database=verwaltung;Uid=root;Pwd=rootpb292;", "LogsTest") _
            .WriteTo.File("test.txt", rollingInterval:=RollingInterval.Day) _
        .CreateLogger()

        BLogError("Hallo .NET 4.6")
    End Sub

End Class