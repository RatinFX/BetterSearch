# Discontinued

- as VEGAS Pro 20.0 and up has objectively better search
- and I created [VPConsole](https://github.com/RatinFX/VPConsole)

---

# Better Search

Improved search for Effects, Generators, and their Presets.

![](preview.png)

## Overview

Quickly search and find **VideoFX**, **AudioFX** and **Generators**

**Add or Remove** from your **Favorite list** by **right clicking** on an **item**

## Settings descriptions

- **Only Show Favorites**

- **Check or Update on Start**

## How to install

Make sure you have at least [.NET 4.8 (or higher)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer) installed on your computer.

### Quick install

1. Download "...13" for **13 and earlier**, or "...14" for **14 and later** Vegas Pro versions
2. **Run the .exe** file, this automatically extracts the files to the selected folder
3. Click Next with the default options and wait for it to finish
4. Start VEGAS Pro and search for the **Extension** under **Tools - Extensions**

### Manual install

1. Download "...13" for **13 and earlier**, or "...14" for **14 and later** Vegas Pro versions
2. Go to your **AppData - Roaming - Vegas Pro** folder by typing the following into your Windows Explorer:
   > %appdata%\Vegas Pro
3. **Find or create** an **Application Extensions** folder, the path to it should looks like this:
   > ...\AppData\Roaming\Vegas Pro\Application Extensions
4. Extract the contents of the .zip file into the folder above
5. Start VEGAS Pro and search for the **Extension** under **Tools - Extensions**
## Build

Import the correct reference:

Project -> Add reference -> Browse -> Your VEGAS install folder ->

- `ScriptPortal.Vegas.dll` for SONY Vegas Pro 13 and below

- `Sony.Vegas.dll` for MAGIX Vegas Pro 14 and above
