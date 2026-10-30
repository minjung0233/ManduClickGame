# ManduClickGame

An unfinished Unity clicker game prototype for Android. Players tap dumplings to earn more, improve the click level, and build toward passive dumpling generation.

## Gameplay prototype

- Tapping adds dumplings; higher `ManduClickLevel` values increase the amount gained per tap.
- `ManduAutomaticLevel` is planned to generate dumplings without tapping.
- Newly added dumplings appear around the player with a scale-up and fade-out effect.
- Player data is saved as JSON.

The current click rewards are documented as:

| Click level | Dumplings gained per tap |
| --- | --- |
| Level 1 | 1–3 |
| Level 2 | 3–5 |
| Level 3 | 5–7 |

## Project status

This is a work in progress. The repository notes a start screen, sound, and an upgrade shop as planned features. The automatic-generation upgrade is also unfinished.

## Open the project

1. Open the Unity project folder in Unity Hub.
2. Use the Unity version listed in `ProjectSettings/ProjectVersion.txt`.
3. Open the project and run its current scene in the Editor.

The repository includes the Unity solution `ManduClickGame.sln` for IDE use.
