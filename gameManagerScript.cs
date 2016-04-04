using UnityEngine;
using System.Collections;

public class gameManagerScript : MonoBehaviour 
{

	int currentLevel;
	int numLives;
	int numPoints;
	int playerNum;
	public int lastPosition;

	// up, down, left, right, fullBody 
	public Sprite[] playerOne;
	public Sprite[] playerTwo;
	public Sprite[] playerThree;
	public Sprite[] playerFour;

	bool died;


	public void justWonLevel(int level)
	{
		died = false;

		if (level == 9) 
		{
			winGame ();
		}

		if (level == currentLevel) 
		{
			if (level == 8) 
			{
				lastPosition = 9;
			}

			currentLevel += 1;
		}
	}
		

	public void setLastPosition(int level)
	{
		died = false;
		lastPosition = level;
	}

	public void setPlayerNum(int num)
	{
		playerNum = num;
	} 

	public Sprite setSprite()
	{
		if (playerNum == 1) 
		{
			return playerOne [0];
		}

		else if (playerNum == 2) 
		{
			return playerTwo [0];
		}

		else if (playerNum == 3) 
		{
			return playerThree [0];
		}

		else
		{
			return playerFour [0];
		}

	}

	public bool dead()
	{
		return died;
	}

	public int getPlayerNum()
	{
		return playerNum;
	}

	public void setCurrentLevel(int level)
	{
		lastPosition = level;
		currentLevel = level;
	}

	public int getCurrentLevel()
	{
		return currentLevel;
	}

	public int getNumLives()
	{
		return numLives;
	}

	public void setNumLives()
	{
		numLives = 5;
	}

	public void loseLife()
	{
		died = true;
		numLives -= 1;
	}

	public Sprite getFacingSprite(string face)
	{
		// face == up, down, left, right, full

		if (playerNum == 1) 
		{
			if (face == "up") {
				return playerOne [0];
			} else if (face == "down") {
				return playerOne [1];
			} else if (face == "left") {
				return playerOne [2];
			} else if (face == "right") {
				return playerOne [3]; 
			} else if (face == "full") {
				return playerOne [4];
			} else {
				return playerOne [5];
			}
		}

		else if (playerNum == 2)
		{
			if (face == "up") {
				return playerTwo [0];
			} else if (face == "down") {
				return playerTwo [1];
			} else if (face == "left") {
				return playerTwo [2];
			} else if (face == "right") {
				return playerTwo [3]; 
			} else if (face == "full") {
				return playerTwo [4];
			} else {
				return playerTwo [5];
			}
	
		}

		else if (playerNum == 3)
		{
			if (face == "up") {
				return playerThree [0];
			} else if (face == "down") {
				return playerThree [1];
			} else if (face == "left") {
				return playerThree [2];
			} else if (face == "right") {
				return playerThree [3]; 
			} else if (face == "full") {
				return playerThree [4];
			} else {
				return playerThree [5];
			}
		}  

		else 
		{
			if (face == "up") {
				return playerFour [0];
			} else if (face == "down") {
				return playerFour [1];
			} else if (face == "left") {
				return playerFour [2];
			} else if (face == "right") {
				return playerFour [3]; 
			} else if (face == "full") {
				return playerFour [4];
			} else {
				return playerFour [5];
			}
		}
	}

	public void gameOver()
	{
		// ran out of lives
		// game over
		// play again?
		// exit

		Application.LoadLevel ("gameOver");
	}

	public void winGame()
	{
		// play again?
		// exit
		Application.LoadLevel ("youWin");
	}

	void Start()
	{
		died = false;
		currentLevel = 0;
		numLives = 5;
	}

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	void Update()
	{
		Debug.Log (died);
	}
}
