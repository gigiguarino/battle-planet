# battle-planet

I attended MHacks 2016, and this is what I created. <br>
MHacks is a hackathon at the University of Michigan, it lasts 36 hours. <br>

I used Unity to develop this game. <br>
Coding language is C#, I also utilized Unity's API.

This is a shooting game that takes place on each of the planets in our solar system. <br>
Finally, ending up at the sun and battling the boss to win. 

###Controls: <br>
When on the level map: <br>
Move with the arrow keys, enter a planet with the enter key. <br>
Esc to go to main menu. <br><br>
When on a planet: <br>
Shoot with the spacebar, move with the arrow keys. 

###Rules: <br>
On each planet, enemies are spawned from caves/huts. <br>
You must shoot the huts until they dissapear and kill all the enemies that show up <br>
to beat the planet and move on the next one.

###Files: <br>
bossHutScript1.cs - Controls the mid-game boss's hut. <br>
bossScript1.cs - Controls a mid-game boss, he has different attributes than the other enemies.<br>
bulletScript.cs - Controls the bullets, and inflicts damage to enemies and huts. <br>
cameraScript.cs - Controls the camera.<br>
enemyEasyScript.cs - Controls the easy enemies. Regular speed, regular amount of bullets to kill.<br>
enemyHardScript.cs - Controls the hard enemies. Slow, but take a lot of bullets to kill. <br>
enemyMediumScript.cs - Controls the medium enemies. Fast, but take fewer bullets to kill. <br>
exitButton.cs - Controls the actions of the exit button.<br>
finalBossBattleScript.cs - Controls the final boss, he has different stats than all previous enemies.<br>
gameManagerScript.cs - Keeps track of player's lives and progress throughout all levels.<br>
hutEasyScript.cs - Controls the huts that spawn the easy enemies.<br>
hutHardScript.cs - Controls the huts that spawn the hard enemies.<br>
hutMediumScript.cs - Controls the huts that spawn the medium enemies<br>
levelMapScript.cs - Controls the map that contains all the different levels (planets).<br>
playAgainButton.cs - Controls the play again button. Restarts the game. <br>
playerChooseHoverScript.cs - <br>
playerScript.cs - Controls the player's movement, gun shooting, and actions while on planets. <br>
resolutionHelp.cs - Helps with a frame speed error.<br>
rulesButtonScript.cs - Controls the button that shows the rules.<br>
rulesScript.cs - Directs players back to the main menu, after showing the rules. <br>
startButtonScript.cs - Controls the start button. Starts the game. <br>
titleMenuScript.cs - Controls the words on the title menu, and the buttons. <br>
