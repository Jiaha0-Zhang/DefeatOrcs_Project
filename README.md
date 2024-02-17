# DefeatOrcs_Project

## Introduction

This is a Top Down RPG project using the Unity engine and C#, and all I did was basically write scripts for character and orc monsters, including the design of the character and orcs movement, trigger detection zone, health, attack power and a series of numerical calculations,etc. Then hang the different scripts wherever they are needed. 

## Scripts

### Floating Damage Popup effect

This script is mainly written to show the damage value after the character attacks, and slowly disappear after a certain time.
* [DamagePopup](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/DamagePopup.cs)

### Detection Zone

These scripts are for the character at what range will trigger the orcs alarm and move towards the character and attack, and the character can not be selected and continue to attack in the case of death.
* [DamageableCharactor](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/DamageableCharactor.cs)
* [DetectionZone](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/DetectionZone.cs)

### Player and Orcs Movement

These two scripts are for the movement of the player character and the orcs
* [OrcMovement](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/OrcMovement.cs)
* [PlayerMovement](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/PlayerMovement.cs)

### Numerical setting

This script is mainly to set the in-game damage number, attack control, and short range knockbackForce effect after being attacked.
* [PlayerSword](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/PlayerSword.cs)
* [IDamageable](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/IDamageable.cs)

### Game Assets
* [GameAssets](https://github.com/Jiaha0-Zhang/DefeatOrcs_Project/blob/main/Scripts/GameAssets.cs)

## Summary and Experience
This is a project that I did on my own, and the models in the game come from a free resource of Unity Asset Store(https://assetstore.unity.com/packages/2d/characters/tiny-rpg-forest-114685). Because most of the models and components were prepared, so the main challenge was writing the scripts, which was the first project I did on my own without any help from others. At that time, I set all the values very small and kept them in the tens, also made a critical strike value effect and distinguished its Popup effect from normal attacks by changing its color. Then there are some triggers, putting the character into the orc's attack range will cause the orc to chase and attack, and when the character has run a certain distance, the Orc trigger can also be eliminated, depending on the movement speed value change and the clever use of terrain. 
