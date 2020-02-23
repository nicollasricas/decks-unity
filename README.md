# Stream Deck for Unity

Enables Stream Deck integration within Unity.

**It should work with any Unity version as long it targets .NET 4.0+.**

## Getting Started

---

1. Download the _Unity_ plugin for Stream Deck on Stream Deck Store or [here](https://github.com/nicollasricas/streamdeck-unity/releases/latest).
2. Download the [Unity package](https://github.com/nicollasricas/unity-streamdeck/releases/latest) and [import](https://docs.unity3d.com/Manual/AssetPackages.html) in any Unity project you wish to use it.

If you have downloaded the plugin and imported the package into your project, you should see this message:

![Live Link Connected](https://user-images.githubusercontent.com/7860985/75047460-2a083100-549d-11ea-817c-1d1a48c76250.png)

**If for some reason the live link lost the connection it will automatically reconnect.**

## Features

---

- Execute menus.
- Switch between scene and game view.
- Reset and rotate objects.
- Paste component.
- Pause/resume play mode.
- Paste component values (delayed due to a bug).
- Select paint layers and brushes (delayed, needs more testing to ensure compatibility with versions older than 2019.\*).

### Execute Menu

To execute a menu, you have to write the full path, spaces included. Submenus use a slash (/) as a divider.

![menupath](https://user-images.githubusercontent.com/7860985/75050243-01cf0100-54a2-11ea-9744-207a4a8ab2d5.png)

e.g.: Window/Layouts/4 Split.
