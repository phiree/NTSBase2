@echo off
set backupFilename=E:\\aaaa\\%DATE:~0,10%%Time:~0,2%%Time:~3,2%%Time:~6,2%
echo %backupFilename%
md %backupFilename%
xcopy E:\\workspace\\code\\NTSBase2 /s %backupFilename%
pause 
