@echo off
cd D:\btlweb2\btlweb2\index\index
start "IIS Express" "C:\Program Files (x86)\IIS Express\iisexpress.exe" /path:D:\btlweb2\btlweb2\index\index /port:8080 /hostname:localhost
start chrome http://localhost:8080

pause
