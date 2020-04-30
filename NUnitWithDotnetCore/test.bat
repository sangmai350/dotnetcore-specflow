SETLOCAL
SET TestUser=mngr251696
SET TestPassword=pYpunys
SET TestUrl=http://demo.guru99.com/V4/
SET TestCategory=regressiontest
SET Report=yes
dotnet test H:\FOR_WORK\dotnetcore-specflow\NUnitWithDotnetCore\bin\Debug\netcoreapp3.0\NUnitWithDotnetCore.dll --filter TestCategory=%TestCategory%

cmd /k