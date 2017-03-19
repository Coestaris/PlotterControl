@echo off
TITLE SKETCH UPLOADER
chdir /d "%1"
echo It can takes few minutes, so please wait.
echo         --------------==--------------
call arduino_debug.exe --board %2 --port %3 --upload %4
echo END!
echo         --------------==--------------
exit /b 0