del "spy-instalador.exe"
del "spy-instalador.deps.json"
del "spy-instalador.dll"
del "spy-instalador.pdb"
del "spy-instalador.runtimeconfig.json"


copy /Y ".\spy-instalador\spy-instalador\bin\Debug\net8.0-windows\*.*" ".\*.*"
pause
