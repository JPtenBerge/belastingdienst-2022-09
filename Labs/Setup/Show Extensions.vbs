set oShell = WScript.CreateObject("Wscript.Shell") 
RegPath = "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\HideFileExt"
oShell.RegWrite Regpath, 0, "REG_DWORD"
oShell.SendKeys "{F5}"
