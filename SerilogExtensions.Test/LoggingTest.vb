Imports Brandgroup.SerilogExtensions2.Enrichers
Imports Xunit
Imports Brandgroup.SerilogExtensions2.SerilogExtensions
Imports Brandgroup.SerilogExtensions2.Sinks.MySql
Imports Brandgroup.SerilogExtensions2.Sinks.File
Imports Serilog

Public Class LoggingTest

    <Fact>
    Sub SqlTestSub()
        Log.Logger = New LoggerConfiguration() _
                .Enrich.FromLogContext() _
                .Enrich.With(New BrandgroupEnricher()) _
                .WriteTo.BrandMySql("Server=srvfbmysql;Database=verwaltung;Uid=root;Pwd=rootpb292;", "logstest") _
                .WriteTo.BrandFile("logstest123.txt", RollingInterval.Day) _
                .CreateLogger()

        BLogInformation("Startup")

        BLogInformation("Hallo .NET 8")

        BLogInformation("Hallo .NET 8 (Kein MySQL) {NoMySql}")
    End Sub

    <Fact>
    Public Sub TestSub()
        Log.Logger = New LoggerConfiguration() _
            .Enrich.FromLogContext() _
            .Enrich.With(New BrandgroupEnricher()) _
            .WriteTo.BrandFile("log.txt", rollingInterval:=RollingInterval.Day) _
            .WriteTo.File("lograw.txt", rollingInterval:=RollingInterval.Day) _
        .CreateLogger()

        BLogInformation("Startup")

        BLogInformation("Hallo .NET 8 (Kein File) {NoFile}")

        BLogInformation("Hallo .NET 8 File")
    End Sub
End Class