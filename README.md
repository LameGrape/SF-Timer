# SF Timer
A Stick Fight speedrun timer for BepInEx.

The timer starts when spawn in, and stops when you die. It is useful for speedrun maps such as BOTF.

For a tutorial on installing BepInEx, see https://docs.bepinex.dev/articles/user_guide/installation/index.html. After installation (or if it already installed), download the DLL from the releases tab on the right, and put it into the BepInEx plugin folder.

## Planned Features
* Proper multiplayer support. Currently, every player spawns a timer, making them stack.
* Resetting. Pressing a button will kill and auto respawn the player. (Only in private lobbies and the editor)
* Win Objective. Collecting a golden gun will stop the timer. Custom win objectives per level may need to be implemented due to BOTF levels having more than one golden gun.
