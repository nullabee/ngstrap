@echo on

rd %USERPROFILES%\.nuget\packages /s /q
rd %USERPROFILES%\AppData\Roaming\npm-cache /s /q
rd src\webng2\node_modules /s /q

rd publish /s /q
rd publish.tmp /s /q
del publish*.zip 

del /S project.lock.json
