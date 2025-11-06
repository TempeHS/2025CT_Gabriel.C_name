
# 2025CT_Gabriel.C_Conquest

<img width="679" height="384" alt="Screenshot 2025-11-06 at 11 33 03 am" src="https://github.com/user-attachments/assets/765eefa8-2ca4-46a0-8817-f826f227a8b1" />


<h2 align="center">Table of Contents</h2>

- [Gameplay & Map Showcase](#Gameplay-&-Map-Showcase)
- [Gameplay](#Gameplay)
- [Map Showcase](#Map-Showcase)
- [General Information](#General-Information)
  - [About](#About)
  - [Objective](#Objective)
  - [Inspirations](#Inspirations) 
  - [Story](#Story)
  - [Music](#Music)
  - [Keyboard and Mouse Controls](#Keyboard-and-Mouse-Controls)
- [Script Editing Software](#Script-Editing-Software)
- [How I made Platforms](#How-I-Made-Platforms)
- [Wall Jump](#Wall-jump)
- [Dash Particles](#Dash-Particles)
- [Main Scripts](#Main-Scripts)
- [Asset Showcase](#asset-showcase)
- [Public Assets Used](#public-assets-used)
- [Showcase of Works](#showcase-of-works)
- [All Tutorials](#All-Tutorials-Used)
- [Authors](#Authors)
---

## Gameplay & Map Showcase




### Gameplay
https://github.com/user-attachments/assets/b69e618c-c9dd-4040-93a5-4cb3ee46b0af


### Map Showcase

https://github.com/user-attachments/assets/cdbf2b21-d6fe-41ff-9789-993083d0e591




---
                    
# General Information
## About
<p align="justify">
My Game Conquest is a platformer where you play as a box whos goal about climbing to the top of the world to get the gold at the end while many challenges await. The game has many features implented like wall jump, platforms, a dash feature with particle effects and red spikes that will take you back to the start of the game. 

It also has a title screen with an adventurous vibe and music that matches the intense gameplay, making the experience more immersive. Controls are smooth and responsive, and the higher you go the harder it gets where there are less platforms and more spikes meaning it heavily challenges the players skill. My game is all about improving, learning from mistakes, and mastering  movement as you push to reach the final goal. 

## Objective
<p align="justify">
The objective of the game is to jump across different platforms, avoid dangerous spikes, and climb all the way to the top until you reach the gold. The game tests your timing, focus, and patience as each level gets harder the higher you go. Quick reflexes and smart moves will help you prevail with one wrong jump means you will fall down to a lower platform or even start all over again.</p>

## Inspirations
<p align="justify">
My Game Conquest is inspired from games such as Getting Over It and  Only Up!  where the player has to climb a set of obstacles to reach the top and one wrong mistake can bring you right back to the start. I love these sorts of punishing games as it makes sure the players are careful of there moves and when you finally beat it it's very rewarding.

## Story
<p align="justify">
</p> The game follows a simple story:where the player (you) wakes up in a big world called conquest. You will plays as a little box whos is is facing the daring adventure with only one goal in mind: make it to the top and steal take the shiny pile of gold. The backgrounds change as you get higher, the 4 backgrounds are the Grasslands, Space, The Desert and the Mountains 

## Music

<p align="justify">
To add music into my game, I created a GameObject in Unity called MusicHandler. I then added an Audio Source component to it. In the Audio Source, I put my music file in the audio clip slot. I also turned on Play On Awake so the song starts as soon as the start button is pressed in the main menu, and I ticked Loop so the music keeps repeating instead of stopping after one play.
</p>
<img width="338" height="418" alt="Screenshot 2025-11-06 at 11 50 54 am" src="https://github.com/user-attachments/assets/b6888fb7-1487-42c4-99a8-a0c11f229f04" />
</p>

I then made a simple script called NewBehaviourScript, which I attached to the same object. Inside the script, I used the Awake() method and wrote DontDestroyOnLoad(this);. This makes sure the music keeps playing even when I switch scenes, instead of restarting or stopping.


<img width="484" height="248" alt="Screenshot 2025-11-06 at 11 49 59 am" src="https://github.com/user-attachments/assets/a9cbce10-0336-4ffd-8e18-f4ede6c11587" />
</p>

Basically, this setup means the background music starts when the game starts, loops forever, and doesn’t stop when I move to different levels or menus.

The games' catchy audio track in the background is provided by my cousin: Andrew Lambrou.

Follow his music here: https://www.youtube.com/@AndrewLambrou
</p>
Excact Song used in My Game: https://www.youtube.com/watch?v=wMvVW4jRFZ8&list=RDwMvVW4jRFZ8&start_radio=1
</p>


## Keyboard and Mouse Controls

| Action        | Output                              |
| ------------- | ----------------------------------- |
| **A**         | Move Left                           |
| **D**         | Move Right                          |
| **S**         | Move Down on *some* platforms       |
| **Left Shift**| Dash                                |
| **Space**     | Jump                                |

---

## Script Editing Software

### Visual Studio
Visual Studio is a program that lets you write and edit code for your games. It’s like the brain behind Unity, where you type all the C# scripts that control what happens in your game like how a player moves, how enemies act, or when music plays.
</p>
<img width="647" height="302" alt="Screenshot 2025-11-05 at 9 08 49 pm" src="https://github.com/user-attachments/assets/9a25b3de-a1fa-4c07-af5e-853792a81701" />

---
# How I Made Platforms
To make my platforms for my platformer, I used a simple Square sprite and adjusted its Transform values to change the size and position.I changed the size of each platform to be wider and bigger so it would be easier for the players to use. Then, I added a Box Collider 2D so the player’s character could walk and jump on top of it which gives the platform collision and makes it solid.

The Sprite Renderer lets me control how the platform looks, including the color and layer order. I kept the Draw Mode as Simple and used the Default material since I only needed basic visuals for my game.

<img width="321" height="686" alt="Screenshot 2025-11-06 at 2 40 45 pm" src="https://github.com/user-attachments/assets/aff9908a-4ab5-415e-a969-92547a627625" />

My PlayerMovement script interacts with the platform using Unity’s ground check system. The player uses a small groundCheck object that detects when it’s touching something on the Ground layer which includes my platforms. When the player touches the ground, it can jump again.
## Wall Jump
The wall jump works by detecting when the player’s collider touches a wall collider using Physics2D.OverlapCapsule. When this happens and the player presses jump, the script directly changes the Rigidbody2D’s velocity, giving it an instant push away from the wall and a boost upward.

Because it uses Unity’s physics system, gravity still affects the player during and after the wall jump, which makes the movement feel natural. The wall colliders stop the player from moving through them, while the velocity change lets the player bounce off instead.
## Dash Particles
To upgrade the dash feature, I used a Trail Renderer component attached to the player. This creates a visual trail that follows behind when the player dashes. In my script, I referenced it using [SerialField] private TrailRenderer tr; so I could control it through code.

When the player dashes, the coroutine Dash() starts. Inside it, I set tr.emitting = true, which makes the trail appear while the player’s Rigidbody2D moves quickly in the dash direction. After the dash finishes, I turn it off with tr.emitting = false so the trail only shows during that burst of speed.
</p>
<img width="339" height="692" alt="Screenshot 2025-11-06 at 3 00 31 pm" src="https://github.com/user-attachments/assets/88f337e8-cf95-462c-962b-ea4162398a7f" />
</p>

## Main Scripts

- [Camera Controller](https://github.com/TempeHS/2024IST_Kelvin.A_Knights.Light/blob/main/My%20project/Assets/Scripts/Cameracontroller.cs)
- [Camera Zoom](https://github.com/TempeHS/2024IST_Kelvin.A_Knights.Light/blob/main/My%20project/Assets/Scripts/CameraZoom.cs)
- [Enemy Controller](https://github.com/TempeHS/2024IST_Kelvin.A_Knights.Light/blob/main/My%20project/Assets/Scripts/EnemyController.cs)
- [Player Movement](https://github.com/TempeHS/2025CT_Gabriel.C_name/blob/main/Assets/Scripts/PlayerMovement.cs)
- [Main Menu](https://github.com/TempeHS/2024IST_Kelvin.A_Knights.Light/blob/main/My%20project/Assets/Scripts/MainStory.cs)
- [Parralax](https://github.com/TempeHS/2025CT_Gabriel.C_name/blob/main/Assets/Scripts/Parralax.cs)
- [Music](https://github.com/TempeHS/2025CT_Gabriel.C_name/blob/main/Assets/Scripts/Music.cs)
- [Main Menu](https://github.com/TempeHS/2025CT_Gabriel.C_name/blob/main/Assets/Scripts/MainMenu.cs)
- [Death Script](https://github.com/TempeHS/2025CT_Gabriel.C_name/blob/main/Assets/Scripts/DeathScript.cs)
---


## Asset Showcase

- [View All Assets](https://github.com/TempeHS/2025CT_Gabriel.C_name/tree/main/Assets)

---

## Public Assets Used

- [Free 2D Cartoon Parallax Background][https://assetstore.unity.com/packages/essentials/tutorial-projects/happy-harvest-2d-sample-project-259218)](https://assetstore.unity.com/packages/2d/environments/free-2d-cartoon-parallax-background-205812)

---

## Showcase of Works
<img width="660" height="314" alt="Screenshot 2025-11-05 at 12 39 36 pm" src="https://github.com/user-attachments/assets/b9c4b0de-712f-4f56-95f7-a8deddd4d94d" />
<img width="660" height="314" alt="Screenshot 2025-11-05 at 12 40 12 pm" src="https://github.com/user-attachments/assets/d931cfab-03dd-4b00-b7f2-3453e422038a" />
<img width="617" height="333" alt="Screenshot 2025-11-05 at 7 51 56 pm" src="https://github.com/user-attachments/assets/54bd750f-5c3e-416f-9be3-ff86268fd1f5" />
<img width="451" height="88" alt="Screenshot 2025-11-06 at 2 09 39 pm" src="https://github.com/user-attachments/assets/d778b99e-f7c5-4be5-af99-053896e65d82" />



## All Tutorials Used
| Function | Tutorial Link |
| ----------- | ----------- |
| Player Movement | https://www.youtube.com/watch?v=K1xZ-rycYY8 |
| Parralax | https://www.youtube.com/watch?v=ZYZfKbLxoHI |
| Spike Mechanic | https://www.youtube.com/watch?v=kV9rVinFyAk |
| Main Menu | https://www.youtube.com/watch?v=kV9rVinFyAk |
| Wall Jump | https://www.youtube.com/watch?v=sfDnN-Im7rY |
| Dash Feature | https://www.youtube.com/watch?v=2kFGmuPHiA0 |
| Music | https://www.youtube.com/watch?v=N8whM1GjH4w |


### Authors

:computer: Developer - Gabriel Chitos Djapouras



