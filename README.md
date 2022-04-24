# Escape
[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=flat&logo=unity)](https://www.unity.com)

This is a 2D Top-down view stealth game **prototype** with 1-bit pixel art as art style.

<img src="https://github.com/xPoke-glitch/Escape/blob/main/Screenshots/screen.png" width="750">

## The Game

The objective is to escape from each room / level! Find the floor's ladders to escape to the next room.

Be careful, avoid guards or slay them if you find a sword in the floor. If a guard sees you, it will start to chase you! if you get caught you will lose a life and restart the level.

There is a nice tutorial scene in the project, I suggest you to follow it! (Sorry the dialogues are in italian only right now)

The game is not completed, it's just a prototype, but it has all the components to create as many levels as you want.

## Requirements

If you only want to run the game and play:
* Windows 64bit

If you want to open, edit or see the Unity project:
* Unity 2020.3.26f1 (or greater)

## How to play

In order to play the game you have two options:
* Open the project with the recommended Unity version and play it from the game window
* Open the project with the recommended Unity version and build it for your platform

The commands are really simple:
* W/A/S/D: Move the player
* K: Go through a dialogue

## Gameplay example

This is an example that shows you how the game looks like. This is the first and only level that there is right now:

<img src="https://github.com/xPoke-glitch/Escape/blob/main/Screenshots/gameplay.gif" width="750">

There is also a cool dialogue system that I created using Inky files:

<img src="https://github.com/xPoke-glitch/Escape/blob/main/Screenshots/dialogue.gif" width="750">

## Test notes

This project was made mainly for testing and creating a dialogue system with Inky files. Those files are extremly helpful to create dialogues!

I also tested for the first time a grid base pathfinding with A* algorithm for guards AI - this because you can't count on NavMesh for 2D Games with Unity

The game works as intended, it has all the components to create many more levels! I didn't create them because of no time.

## Team

**Developers**:
* Cristian: https://github.com/xPoke-glitch / https://pokedev.itch.io/
