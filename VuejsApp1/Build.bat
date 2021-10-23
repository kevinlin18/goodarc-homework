ECHO "0.建立View資料夾" &&^
powershell -Command "New-Item -ItemType directory -Force -Path ..\goodarc-homework\Views\Home" &&^
powershell -Command "New-Item -ItemType directory -Force -Path ..\goodarc-homework\wwwroot" &&^
ECHO "1.Build Vuejs專案" &&^
npm run-script build && ^
ECHO "2.刪除ASP專案wwwroot的舊網頁" &&^
powershell -Command "Get-ChildItem -Path ..\goodarc-homework\wwwroot -Include * -File -Recurse | foreach { $_.Delete()}" &&^
ECHO "3.將index.html複製到ASP專案的View" &&^
powershell -Command "(gc -Encoding UTF8 .\dist\index.html) | Out-File -Encoding UTF8 ..\goodarc-homework\Views\Home\Index.cshtml" &&^
ECHO "4.刪除index.html" &&^
del .\dist\index.html &&^
ECHO "5.複製其餘檔案到ASP專案wwwroot" &&^
xcopy /s/y .\dist ..\goodarc-homework\wwwroot