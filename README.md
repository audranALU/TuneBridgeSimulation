# TuneBridge – Bass Basics Simulation

Created by Audran Ndayisenga for the Mission-Based Interactive Simulation assignment.

## GCGO and Mission

GCGO: Art and Culture.

My mission is to use technology to help instrumentalists gain recognition,
connect with audiences, and access learning and mentorship opportunities,
starting in Rwanda and expanding across Africa.

## Problem Context

Beginner instrumentalists may struggle to access mentors and practical
learning opportunities. Instrumentalists can also receive less recognition
than lead performers.

TuneBridge introduces beginners to the bass guitar through a short,
interactive lesson. It supports the learning part of my broader mission.

## Simulation Overview

TuneBridge is a first-person simulation set in a small music academy room.

Target users: beginner bass players and people interested in learning
about musical instruments.

The player:
1. Approaches the bass guitar and presses E to read the lesson.
2. Walks into the practice area to answer a tuning question.
3. Answers correctly, then approaches and interacts with the amplifier.
4. Sees a cable connect the instruments, hears audio, and earns a saved
   completion achievement.

## Controls

- WASD: Move.
- Mouse: Look around.
- E: Interact while aiming at the bass guitar or amplifier.
- Mouse click: Select a quiz answer.

## Unity Mechanics Implemented

### User Interface
TextMeshPro displays instructions, lesson content, quiz answers, feedback,
and achievement status. Buttons allow the player to answer the quiz.

### Scripting
C# scripts manage player movement, lesson progression, quiz answers,
amplifier interaction, cable display, animation, and achievement saving.

### Collision and Triggers
The CharacterController interacts with the environment's colliders.
A trigger in the practice area detects the player and opens the quiz
after the lesson has been read.

### Raycasting
A ray is cast forward from the camera to detect the bass guitar or
amplifier. Interactions require the player to aim at the correct object
within the interaction distance.

### Line Renderer
A Line Renderer displays the cable between the bass guitar and amplifier
after the player passes the quiz and interacts with the amplifier.

### New Input System
Input Actions handle movement, looking, and interaction.
The EventSystem uses InputSystemUIInputModule for UI input.

## Additional Features

1. Audio: An AudioSource plays a bass recording when the connection is made.
2. Scripted animation: The practice marker pulses to attract attention.
3. Persistence: PlayerPrefs saves the lesson completion achievement
   between sessions. The lesson itself can be replayed.

## Project Structure

- Assets/Scenes: MusicAcademy scene.
- Assets/Scripts: Gameplay and interaction scripts.
- Assets/Input: Input Actions.
- Assets/Models: Imported instrument models.
- Assets/Materials: Materials used in the environment.
- Assets/Audio: Audio assets.

## Build Information

### WebGL
Play online:
https://play.unity.com/en/games/d46e4728-5fc0-4b78-b4b4-4a03bd1a283a/webglbuild

Use a desktop browser. Click inside the game to capture the mouse,
then use the controls listed above.

### Android
The Android build and touch controls are still in development.
An APK download link will be added after building and testing.

### Run in Unity
1. Clone this repository.
2. Open the project through Unity Hub using Unity 6000.6.0f1.
3. Allow Unity to import assets and restore packages.
4. Open Assets/Scenes/MusicAcademy.unity.
5. Press Play.

## Assets and Credits

- Bass guitar model: Zsky, downloaded from Poly Pizza.
- Amplifier model: Downloaded from Poly Pizza.
- Floor materials: Yughues Free Flooring Materials.
- Room layout, lesson content, and gameplay integration: Audran Ndayisenga.

## Reflection

Keeping the simulation focused on one beginner lesson helped me connect
each Unity mechanic to a clear learning objective.

One challenge was configuring UI interaction with the New Input System.
Adding and configuring the EventSystem allowed the quiz buttons to work.

Future improvements include more bass lessons, guided practice,
mentor information, and improved accessibility.

## Demonstration Video
https://youtu.be/w7xoxEIc4l4