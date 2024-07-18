Imports Brandgroup.SerilogExtensions.Enrichers
Imports Serilog
Imports Xunit
Imports Brandgroup.SerilogExtensions.SerilogExtensions

Public Class UnitTest1


    <Fact>
    Sub TestSub()
        Log.Logger = New LoggerConfiguration() _
            .Enrich.With(new BrandgroupEnricher()) _
            .WriteTo.File("log.txt", rollingInterval:=RollingInterval.Day, outputTemplate := GetBrandgroupTemplate()) _
            .CreateLogger()

        BLogError("Test")

        
    End Sub
End Class