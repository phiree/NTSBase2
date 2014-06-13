@echo off
set random1=%random%
set random2=%random%
set totalrandom=%random1%%random2%
set backupFilename=F:\\Backup\\code\\ntsbase\\%DATE:~0,10%-%totalrandom%
echo %backupFilename%
md %backupFilename%
xcopy E:\\workspace\\code\\NTSBase2 /s %backupFilename%  /EXCLUDE:%cd%\excludedfileslist.txt /q
echo close after 10 seconds
ping -n 2 localhost>nul
echo close after 9 seconds
ping -n 2 localhost>nul
echo close after 8 seconds
ping -n 1 localhost>nul
echo close after 7 seconds
ping -n 1 localhost>nul
echo close after 6 seconds
ping -n 1 localhost>nul
echo close after 5 seconds
ping -n 1 localhost>nul
echo close after 4 seconds
ping -n 1 localhost>nul
echo close after 3 seconds
ping -n 1 localhost>nul
echo close after 2 seconds
ping -n 1 localhost>nul
echo close after 1 seconds
ping -n 1 localhost>nul




 

