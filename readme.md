# 🏃 Endless Runner Game

A simple **endless runner game** built with **Unity (C#)** where the player runs forward automatically, switches lanes to avoid obstacles, and earns score over time.

---

## 🎮 Gameplay Features

- Automatic forward movement  
- 3-lane system (Left / Middle / Right)  
- Keyboard controls (A/D or Arrow Keys)  
- Random obstacle spawning  
- Score increases over time  
- Best score saved locally  
- Endless ground system  

---

## 🕹 Controls

| Action        | Key |
|--------------|-----|
| Move Left    | `A` or `←` |
| Move Right   | `D` or `→` |

---

## 🧱 Project Structure & Scripts

### 📌 `PlayerController.cs`
- Moves the player forward continuously  
- Handles lane switching  
- Stops movement when the player dies  

### 📌 `ObstacleSpawner.cs`
- Spawns obstacles ahead of the player  
- Randomizes lane and distance between obstacles  
- Parents spawned obstacles for a cleaner hierarchy  

### 📌 `GameManager.cs`
- Controls game state (score, best score, game over)  
- Updates UI via `UIManager`  
- Saves best score using `PlayerPrefs`  
- Handles restart logic  
- Manages endless ground movement  

### 📌 `UIManager.cs`
- Updates in-game score and best score  
- Updates Game Over panel text  
- Reads best score from `PlayerPrefs`  

### 📌 `Collision.cs`
- Detects collision between player and obstacles  
- Triggers Game Over through `GameManager`  
