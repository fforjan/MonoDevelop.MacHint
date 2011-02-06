tell application "Interface Builder"
	set numberOfUnsavedDocuments to (count (every document whose modified is true))
	if numberOfUnsavedDocuments > 0 then
		set dialogResult to display dialog "Interface Builder has unsaved files, do you want to save them before continuing the build process ? " buttons {"Yes", "No"} with icon warning
		if button returned of dialogResult = "Yes" then
			set numberOfDocuments to count of documents
			if numberOfDocuments > 0 then
				repeat with counter from 1 to numberOfDocuments
					tell document counter to save
				end repeat
			end if
		end if
	end if
end tell
