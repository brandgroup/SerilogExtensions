Imports Serilog
Imports Xunit
Imports Brandgroup.SerilogExtensions.SerilogExtensions

Public Class UnitTest1


    <Fact>
    Sub TestSub()
        Log.Logger = New LoggerConfiguration() _
            .WriteTo.File("log.txt", rollingInterval:=RollingInterval.Day) _
            .CreateLogger()

        BLogError("TestLog")

        
    End Sub
End Class