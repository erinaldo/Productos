set dest="%~dp0" 
TASKKILL /F /IM selling.exe

set parametro=%1
 Xcopy %parametro%  %dest% /s/c/y

%CD%
start Selling.exe 

exit