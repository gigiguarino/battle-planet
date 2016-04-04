using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelMapScript : MonoBehaviour 
{
	int currentLevel;
	int currentPlanetPos;
	public GameObject manager;

	public Text lives;

	Sprite playerImage;

	public Sprite[] unlockedPlanets;
	public Sprite[] lockedPlanets;
	public GameObject[] planets;
	bool[] planetLockStatus;

	public GameObject[] hearts;
	public Sprite heartFull;
	public Sprite heartEmpty;

	IEnumerator playClip()
	{
		AudioClip thisClip = this.GetComponent<AudioSource> ().clip;
		this.GetComponent<AudioSource> ().Play ();
		Debug.Log ("here");
		yield return new WaitForSeconds(thisClip.length);
		Debug.Log ("here2");
	}


	// Use this for initialization
	void Start () 
	{
		if (manager.GetComponent<gameManagerScript> ().dead() == true) 
		{
			StartCoroutine (playClip ());
		}



		setHearts ();
		planetLockStatus = new bool[11];
		currentLevel = manager.GetComponent<gameManagerScript> ().getCurrentLevel ();
		setPlanetSprites ();
		currentPlanetPos = manager.GetComponent<gameManagerScript> ().lastPosition;
		playerImage = manager.GetComponent<gameManagerScript> ().getFacingSprite ("full");
		this.GetComponent<SpriteRenderer> ().sprite = playerImage;
		Vector3 pos = planets [currentPlanetPos].transform.position;
		//Debug.Log (currentLevel);
		if (currentPlanetPos >= 9) {
			pos.x += 1;
		} else {
			pos.y += 0.7f;
		}

		this.transform.position = pos;
	}

	void setHearts()
	{
		int num = manager.GetComponent<gameManagerScript> ().getNumLives ();

		if (num == 1) {
			hearts [0].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [1].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
			hearts [2].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
			hearts [3].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
			hearts [4].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
		} else if (num == 2) {
			hearts [0].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [1].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [2].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
			hearts [3].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
			hearts [4].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
		} else if (num == 3) {
			hearts [0].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [1].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [2].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [3].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
			hearts [4].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
		} else if (num == 4) {
			hearts [0].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [1].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [2].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [3].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [4].GetComponent<SpriteRenderer> ().sprite = heartEmpty;
		} else if (num == 5) {
			hearts [0].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [1].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [2].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [3].GetComponent<SpriteRenderer> ().sprite = heartFull;
			hearts [4].GetComponent<SpriteRenderer> ().sprite = heartFull;
		}
	}


	void setPlanetSprites()
	{
		for (int i = 0; i < 10; i++) 
		{
			if (i <= currentLevel) 
			{
				planets [i].GetComponent<SpriteRenderer> ().sprite = unlockedPlanets [i];
				planetLockStatus [i] = true;
			} 

			else 
			{
				planets [i].GetComponent<SpriteRenderer> ().sprite = lockedPlanets [i];
				planetLockStatus [i] = false;
			}
		}
	}

	void loadLevel()
	{
		if (currentPlanetPos == 0) {
			Application.LoadLevel ("pluto");
		} else if (currentPlanetPos == 1) {
			Application.LoadLevel ("neptune");
		} else if (currentPlanetPos == 2) {
			Application.LoadLevel ("uranus");
		} else if (currentPlanetPos == 3) {
			Application.LoadLevel ("saturn");
		} else if (currentPlanetPos == 4) {
			Application.LoadLevel ("jupiter");
		} else if (currentPlanetPos == 5) {
			Application.LoadLevel ("mars");
		} else if (currentPlanetPos == 6) {
			Application.LoadLevel ("earth");
		} else if (currentPlanetPos == 7) {
			Application.LoadLevel ("venus");
		} else if (currentPlanetPos == 8) {
			Application.LoadLevel ("mercury");
		} else {
			Application.LoadLevel ("sun");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("left")) 
		{
			// move to next planet level (if possible)
			if (planetLockStatus[currentPlanetPos + 1] == true && currentPlanetPos != 9)
			{
				currentPlanetPos += 1;
				Vector3 pos = planets [currentPlanetPos].transform.position;

				if (currentPlanetPos == 9) 
				{
					pos.x += 1;
				} 

				else 
				{
					pos.y += 0.7f;
				}

				this.transform.position = pos;
			}
		}

		if (Input.GetKeyDown ("right")) 
		{
			// move to previous planet level (if possible)
			if (currentPlanetPos != 0)
			{
				currentPlanetPos -= 1;
				Vector3 pos = planets [currentPlanetPos].transform.position;
				pos.y += 0.7f;
				this.transform.position = pos;
			}
		}

		if (Input.GetKey ("return")) 
		{
			// enter planet that you're standing on
			// open up a window
			loadLevel();
		}

		if (Input.GetKey ("escape")) 
		{
			Application.LoadLevel ("mainMenu");
		}
	}
}
