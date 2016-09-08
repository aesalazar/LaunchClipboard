Launch Clipboard
================

A simple executable that will determine if the current clipboard contains a text string
and, if so, shell execute it.  This is similar to going to Windows Start > Run..., 
pasting the text, and pressing enter.  This can be placed anywhere and assigned a 
hot-key or mouse macro-button for convince.

For example, if the clipboard contains a URL running this will open it in your 
default browser.  Examples:

* "c:\temp\" - open Windows Explorer in the Temp folder.
* "https://www.google.com/" - open URL in default system browser.
* "C:\Users\Ernie\Documents\Book1.xls" - open Book1 in Excel (if installed).

If the content is not text, the path appears invalid, or the file does not appear 
to have an associated program a message popup will be shown.

This is currently set to run under the .NET 4 Client Profile framework which
will need to be present in the system.  If a different framework is desired simply
change the target framework (I have tested it as far back as .NET 2.0).