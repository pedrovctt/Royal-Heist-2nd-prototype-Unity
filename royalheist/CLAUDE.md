# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**Royal Heist v2.0** - A 2D Unity game project using Unity 6000.2.10f1.

## Architecture

### Scripts Structure
- `Assets/scripts/Player.cs` - Main player controller handling movement, animation, and attack input
  - Uses Unity's legacy Input Manager (`Input.GetAxisRaw`, `Input.GetKeyDown`)
  - Animator-driven with integer-based direction states (0=Up, 1=Down, 2=Left, 3=Right)
  - Attack triggered via Space key, uses Animator triggers

### Assets Structure
- `Assets/GameObjects/sprites/vance/` - Player character sprites and animations
  - Idle, walk, attack animations for 4 directions
  - Hurt, shoot, spellcast, slash sprites
- `Assets/scenes/` - Two scenes (scene1.unity, scene2.unity)
- `Assets/scripts/obj/`, `Assets/scripts/bin/` - Build artifacts (ignored by git)

### Key Unity Packages
- 2D feature set (`com.unity.feature.2d`)
- UGUI (`com.unity.ugui`)
- Visual Scripting (`com.unity.visualscripting`)
- Timeline (`com.unity.timeline`)
- Test Framework (`com.unity.test-framework`)

## Development Commands

### Building
Open in Unity Editor (version 6000.2.10f1 or compatible):
```bash
# On Windows with Unity Hub installed
"C:\Program Files\Unity\Hub\Editor\6000.2.10f1\Editor\Unity.exe" -projectPath "c:\Users\pedro\Documents\Minhas coisas\Projetos\Unity\Royal Heist\royalheist"
```

### Testing
- Unit tests: Use Unity Test Framework (included in packages)
- Run tests from Unity Editor: Window > General > Test Runner

### Code Style
- C# scripts in `Assets/scripts/`
- Uses `MonoBehaviour` pattern
- No explicit linting/formatting config found - follows Unity defaults

## Important Notes

- The project uses the legacy Input Manager (not the new Input System)
- Animator parameters: `direction` (int), `isWalking` (bool), `isAttacking` (trigger)
- Player movement is frame-rate independent using `Time.deltaTime`
- Attack system is a TODO - currently only triggers animation
- Git tracks `Assets/scripts/Player.cs` as the main source file

## Git Workflow
- Main branch: `main`
- Recent commits show iterative development on Player.cs