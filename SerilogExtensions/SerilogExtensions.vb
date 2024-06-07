Public Class SerilogExtensions


    Public Shared Function GetBrandgroupTemplate() As String
        Return "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{DnsHostName}] {Message:lj}{NewLine}{Exception}"
    End Function

End Class
