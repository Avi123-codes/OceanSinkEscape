# THE GREAT SINK ESCAPE

## OVERVIEW
Unity 3D vertical physics platformer. Player controls a soap sphere climbing stacked sink platforms while avoiding rising water. Reach the top soap dish to win.

---

## REQUIREMENTS
- Unity 6 LTS (6000.x recommended)
- TextMeshPro
- Unity UI
- AudioMixer (built-in)

---

## SCENES
- Main_Menu (Index 0)
- Main_Sink_Level (Index 1)

---

## CONTROLS
- WASD: Move
- Space: Jump

---

## FOLDERS
Assets/
- Scenes/
- Scripts/
- Audio/
- Prefabs/

---

## CORE SYSTEMS

### PLAYER
- Rigidbody-based movement
- Jump only when grounded
- Layer-based ground detection ("Dishes")

### CAMERA
- Follows player with offset
- Smooth lerp tracking

### LEVEL
- Stacked cylinder platforms (layer: Dishes)
- Bridge cubes for gaps
- Walls to contain play area

### WATER SYSTEM
- Rising water object
- Trigger collision = lose state

### WIN SYSTEM
- Soap_Dish trigger at top
- Trigger collision = win state

### SCORE
- Based on highest Y position reached
- Real-time UI update

---

## AUDIO
AudioMixer Groups:
- Music
- SFX

Exposed parameters:
- MusicVol
- SFXVol

Files required:
- Background_Music
- Button_Click
- Water_Death
- Victory_Chime

---

## UI
Main Menu:
- Start Button → Load Main_Sink_Level
- Options Panel → volume sliders

In-game:
- Score_Text (TMP)
- Win_Panel
- Lose_Panel

---

## BUILD ORDER
1. Scenes setup
2. Player + Rigidbody
3. Camera follow
4. Level geometry
5. Assign "Dishes" layer
6. Water + Win triggers
7. GameManager setup
8. UI setup
9. Audio mixer setup
10. Script attachment
11. Event wiring
12. Audio import
13. Testing

---

## SCRIPTS REQUIRED
- SoapController.cs
- CameraFollow.cs
- GameRules.cs
- MenuController.cs
- WaterRise.cs
- WaterTrigger.cs
- WinTrigger.cs
- DeathTrigger.cs

---

## COMMON ISSUES

### Missing script in Inspector
- Class name must match file name exactly
- Check Console errors

### Trigger not firing
- At least one object must have Rigidbody
- Collider must be "Is Trigger"
- Player tag must be "Player"

### Movement broken
- Check Rigidbody constraints
- Check ground layer assignment

### UI buttons not working
- Function must be public
- Script must be attached to object

---

## COMPLETION CRITERIA
- Player movement works
- Camera follows correctly
- Water kills player
- Win trigger works
- UI panels show correctly
- Audio plays correctly
- Scene transitions work
