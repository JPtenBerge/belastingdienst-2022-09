@ECHO OFF

REM Locate the IDE folder (vswhere will be a better alternative http://bit.ly/2rr0CBx)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\MSTest.exe" (
  SET VSPATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\Extensions\TestPlatform"
)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\MSTest.exe" (
  SET VSPATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\Extensions\TestPlatform"
)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\MSTest.exe" (
  SET VSPATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\Extensions\TestPlatform"
)

%VSPATH%\vstest.console.exe /?

PAUSE
