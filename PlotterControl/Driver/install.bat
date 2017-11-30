@echo off
TITLE DRIVER INSTLLER
@echo Press button INSTALL, and wait for end of process.
@echo Message "Driver Install success!" mean that you can safety close driver install window.
@echo This window will automaticly close after succes
cd Driver\CH341SER\
:NOTEPAD
start /wait SETUP.exe
IF %ERRORLEVEL% == 0 goto QUIT
else goto QUIT

:QUIT
exit