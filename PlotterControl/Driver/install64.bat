@echo off
TITLE DRIVER INSTLLER
@echo Press button INSTALL, and wait for end of process.
@echo Message "Driver Install succes!" mean that you can safety close driver install window.
@echo This window will automaticly close after succes
cd Driver\CH341SER\
:NOTEPAD
start /wait DRVSETUP64.exe
IF %ERRORLEVEL% == 0 goto QUIT
else goto QUIT

:QUIT
exit