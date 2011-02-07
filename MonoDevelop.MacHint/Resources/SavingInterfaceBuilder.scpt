on ApplicationIsRunning(appName)
	tell application "System Events" to set appNameIsRunning to exists (processes where name is appName)
	return appNameIsRunning
end ApplicationIsRunning

set interfaceBuilder to "Interface Builder" 
if ApplicationIsRunning(interfaceBuilder) then
	tell application interfaceBuilder
		set numberOfDocuments to count of documents
		if numberOfDocuments > 0 then
			repeat with counter from 1 to numberOfDocuments
				tell document counter to save
			end repeat
		end if
	end tell
end if
