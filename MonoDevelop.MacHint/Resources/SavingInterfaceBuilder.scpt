on ApplicationIsRunning(appName)
	tell application "System Events" to set appNameIsRunning to exists (processes where name is appName)
	return appNameIsRunning
end ApplicationIsRunning

set interfaceBuilder to "Interface Builder"
set monoDevelop to "MonoDevelop" 
if ApplicationIsRunning(interfaceBuilder) then
	tell application interfaceBuilder
		set numberOfUnsavedDocuments to (count (every document whose modified is true))
	end tell
	tell application monoDevelop
		if numberOfUnsavedDocuments > 0 then
			set dialogResult to display dialog "Interface Builder has unsaved files.
			
Save them before continuing the build process ?" buttons {"Yes", "No"} with icon caution
			set saveAll to button returned of dialogResult
		else
			set saveAll to "No"
		end if
	end tell
	tell application interfaceBuilder
		if saveAll = "Yes" then
			set numberOfDocuments to count of documents
			if numberOfDocuments > 0 then
				repeat with counter from 1 to numberOfDocuments
					tell document counter to save
				end repeat
			end if
		end if
	end tell
end if
