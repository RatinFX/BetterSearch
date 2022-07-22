# BetterSearch
FX Console but for VEGAS Pro, search and apply FX or generate generators

## Usage
Place the contents of the .zip in the following folder, you have to create it, if it doesn't exist yet:
- `C:\Users\...\Documents\Vegas Application Extensions\`

How to add it as a shortcut (optionally you can just dock it and not worry about opening it up again):
- Options -> Customize Keyboard -> ( if you don't have a separate already: Save As... -> name it then select it -> )
`Show commands containing:` BetterSearch ->
`Shortcut keys:` Shift + Space ( or whatever you'd like to use ) -> `[Add]` -> `[OK]`

Open it here: Tools -> Scripting -> Rescan Script Menu Folder -> click on the script name

Add it to the toolbar in Options -> Customize Toolbar

## Build
Add the correct VEGAS Pro API: `ScriptPortal.Vegas.dll` (14 or after) or `Sony.Vegas.dll` (13 or before) as a Reference to build it.
This uses my [VegasProData](https://github.com/RatinA0/VegasProData) variable collection to make my life easier

## TODO:
- [ ] favs list
- [ ] color code the first on the list? videoFX, audioFX, generators, transitions
- [x] fix close on apply? (-> double click / enter)
