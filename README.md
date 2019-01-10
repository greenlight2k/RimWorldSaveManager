# RimWorld Save Manager #
This is a SaveGame-Editor for RimWorld (rimworldgame.com).

At the moment it supports editing the follwing stats:  
**Colonists**:  Name, Skills, Age, Traits, Backstory, Injuries, Gender, Bodytype, Skincolor, Headtype, Hair, Haircolor, Relations, Items  
**Animals**: Name, Age, Injuries, Training, Relations  
**Items**: Health, Quality, StackCount, Base Material  
**Buildings**: Health, Quality, Material  
**Plants**: Full grow all plants
Supports races made with the Humanoid Alien Framework.  

**Mods that are added by the Steam Workshop are not supported. Only the mods in the "Mod"-folder will be searched for Traits, Backstories and Races.**  

Copy the executable file (.exe) into your game directory and run it.  


**Thanks @ DragonLord and arkatufus for their work on this project!**

#### Disclaimer: Use at your own risk, I am not responsible for your loss of progress. ####

### ChangeLog ###
#### v0.7.1.1 ####
* Add building editing
* Bugfixes
#### v0.7.1.0 ####
* Add item editing for pawn apparel and equipment
* Add item editing for items on ground (StackCount is ignored as there are mods to change it)
* Add options to full grow all plants, set quality and health for all items and remove all filth
* Add option to copy colonists and animals (Thanks @RealWorld666 for the idea)
* Bugfixes
#### v0.7.0.0 ####
* Bugfixes
* Add Support for Version 1.0
#### v0.6.2.2 ####
* Bugfixes
#### v0.6.2.1 ####
* Add editing of relations
* Bugfixes
#### v0.6.2.0 ####
* Add editing Gender, Bodytype, Skincolor, Headtype, Hair and Haircolor
* Fix adding some singular traits (kind, greedy, ...)
#### v0.6.1.0 ####
* Add support for "Humanoid Alien Framework"-backstories
#### v0.6.0.1 ####
* Small hotfix for new SaveGames
* Add support for non-Human, playable races, "Humanoid Alien Framework" (Orassans, ...)
* CAUTION: Backstories from mods are not supported.
#### v0.6.0.0 ####
* Code base rewrite
* Put all colonists into a list on the first tab
* Add a second tab for editing animals (name, age, training, injuries)
* Add name editing
* Fix age editing (Biological works, Chonological not 100% working)
* Add bodypart names for humans (injuries)
#### v0.5.4.3 ####
* Major code base rewrite and refactor.
* Changes are made in place on the save file.
* Non-destructive file write, file are not completely rebuild when written to disk, only change deltas are modified.
#### v0.5.4.2 ####
* Fixed background story ID generation bug, background story can be saved properly now.
* Background story combo box pulldown entries are now sorted for less searching headache.
* Fixed background story tooltip so it is less annoying.
#### v0.5.4.1 ####
* Updated to support Alpha 16
* Added default core backstories
#### v0.5.4 ####
* Added extra information to backstories (Trait bonuses and disabled skills)
#### v0.5.3 ####
* Fixed a bug in loading modded traits (Duplicates)
* Added default load/save path to platforms other than Windows
#### v0.5.2 ####
* Fixed another bug in backstory collection (Please post logs)
* Added the ability to modify biological age
#### v0.5.1 ####
* Fixed bug in backstory collection
#### v0.5 ####
* Added backstory editing (experimental)
#### v0.4.2 ####
* Fixed culture dependence in type conversion
#### v0.4.1 ####
* Fixed some loading bugs
* Added the ability to remove injuries and infections
#### v0.4 ####
* Updated to support Alpha 14
#### v0.3 ####
* Added initial support for injuries and infections
* Updated to support Alpha 13
#### v0.2 ####
* Added support for traits
#### v0.1 ####
* Basic editing of skills and passions