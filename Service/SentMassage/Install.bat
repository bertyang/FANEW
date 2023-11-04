%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe SentMassage.exe
Net Start SentMassage
sc config SentMassage start= auto