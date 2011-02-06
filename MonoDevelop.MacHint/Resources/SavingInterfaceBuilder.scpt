tell application "Interface Builder"
  set numberOfUnsavedDocuments to (count every document whose modified is true)
  if numberOfUnsavedDocuments > 0 then
    display dialog "Interface Builder has unsaved files, press Ok to save them or Cancel to stop the build process." with icon warning
  end if
  set numberOfDocuments to count of documents
  if numberOfDocuments > 0 then
    repeat with counter from 1 to numberOfDocuments
      tell document counter to save
    end repeat
  end if
end tell
