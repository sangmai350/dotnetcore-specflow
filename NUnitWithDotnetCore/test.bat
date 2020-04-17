SETLOCAL
SET TestUser=mngr251696
SET TestPassword=pYpunys
SET TestUrl=http://demo.guru99.com/V4/
SET TestCategory=regressiontest
dotnet test C:\Users\yt\Desktop\NUnitWithDotnetCore\NUnitWithDotnetCore\bin\Debug\netcoreapp3.0\NUnitWithDotnetCore.dll --filter TestCategory=%TestCategory%

cmd /k