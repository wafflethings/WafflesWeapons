@echo off

echo This needs setup, and to run as admin. Press enter if you've done that.
pause

:: Set this to your ULTRAKILL path.
set UKPATH="A:\SteamLibrary\steamapps\common\ULTRAKILL"
:: Set this to where your ExtraAlts folder is.
set PATH="C:\Users\mkols\source\repos\ExtraAlts"

rmdir %PATH%"\ExtraAlts_Assets\Assets\Common"

:: YOU NEED ADMIN PERMISSIONS TO CREATE A SYMLINK, RUN THIS AS ADMIN.
mklink /D %PATH%"\ExtraAlts_Assets\Assets\Common" %UKPATH%"\Magenta\Common"

pause