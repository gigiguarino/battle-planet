using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerScript : MonoBehaviour 
{
	public GameObject bullet;

	int level;

	string facing;
	Sprite facingLeft;
	Sprite facingRight;
	Sprite facingUp;
	Sprite facingDown;

	float playerSpeed = 0.05f;
	float bulletSpeed = 10;
	int playerNum;

	public GameObject[] huts;

	string[] planetNames = { "pluto", "neptune", "uranus", "saturn", "jupiter", "mars", "earth", "venus", "mercury", "sun" };

	public GameObject manager;


	void restartLevel()
	{
		// load level map
		// figure out way to tell level map scene this
		// lose a life

		manager.GetComponent<gameManagerScript> ().loseLife ();

		int n = manager.GetComponent<gameManagerScript> ().getNumLives();
		if (n > 0) {
			Application.LoadLevel ("levelMap");
		} else {
			manager.GetComponent<gameManagerScript> ().gameOver ();
		}
			
	}

	void wonLevel()
	{
		// go back to level map
		// move on to next level
		manager.GetComponent<gameManagerScript>().justWonLevel(level);

		if (level == 9) {
			manager.GetComponent<gameManagerScript> ().winGame ();
		} else {
			Application.LoadLevel ("levelMap");
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "enemyEasy" ||
			collider.gameObject.tag == "enemyMedium" ||
			collider.gameObject.tag == "enemyHard" ||
			collider.gameObject.tag == "boss1" ||
			collider.gameObject.tag == "finalBoss") 
		{
			// enemy collided with our player
			// lose this level
			collider.gameObject.SetActive(false);
			restartLevel ();
		}
	}

	bool checkWin()
	{
		for (int i = 0; i < huts.Length; i++) 
		{
			if (huts [i].activeSelf == true) 
			{
				return false;
			}
		}
			
		GameObject[] enemies1 = GameObject.FindGameObjectsWithTag ("enemyEasy");
		GameObject[] enemies2 = GameObject.FindGameObjectsWithTag ("enemyMedium");
		GameObject[] enemies3 = GameObject.FindGameObjectsWithTag ("enemyHard");
		GameObject[] enemies4 = GameObject.FindGameObjectsWithTag ("boss1");
		GameObject[] enemies5 = GameObject.FindGameObjectsWithTag ("finalBoss");

		if (enemies1.Length == 0 && enemies2.Length == 0 && enemies3.Length == 0 && 
			enemies4.Length == 0 && enemies5.Length == 0) 
		{
			return true;
		}

		return false;
	}

	void shootBullet()
	{
		Vector3 position = this.transform.position;
		Vector3 velocity;

		if (facing == "up") 
		{
			// want bullet at top right of player
			position.x += 0.3f;
			position.y += 0.3f;
			velocity = new Vector3 (0, bulletSpeed, 0);
		} 

		else if (facing == "down") 
		{
			// want bullet at bottom left of player
			position.x -= 0.3f;
			position.y -= 0.3f;
			velocity = new Vector3 (0, -bulletSpeed, 0);
		} 

		else if (facing == "right") 
		{
			// want bullet at bottom right of player
			position.x += 0.3f;
			position.y -= 0.3f;
			velocity = new Vector3 (bulletSpeed, 0, 0);
		} 

		else 
		{
			// want bullet at top left of player
			position.x -= 0.3f;
			position.y += 0.3f;
			velocity = new Vector3 (-bulletSpeed, 0, 0);
		}

		GameObject newBullet = Instantiate (bullet, position, Quaternion.identity) as GameObject; 
		Rigidbody2D rb;
		rb = newBullet.GetComponent<Rigidbody2D> ();
		rb.velocity = transform.TransformDirection (velocity);
	}

	void getLevel()
	{
		for (int i = 0; i < planetNames.Length; i++) 
		{
			if (planetNames [i] == SceneManager.GetActiveScene ().name) 
			{
				level = i;
				return;
			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		this.GetComponent<SpriteRenderer> ().sprite = manager.GetComponent<gameManagerScript> ().setSprite ();
		facing = "up";
		this.GetComponent<Rigidbody2D> ().freezeRotation = true; 
		getLevel ();
		playerNum = manager.GetComponent<gameManagerScript> ().getPlayerNum ();
		facingDown = manager.GetComponent<gameManagerScript> ().getFacingSprite ("down");
		facingUp = manager.GetComponent<gameManagerScript> ().getFacingSprite ("up");
		facingLeft = manager.GetComponent<gameManagerScript> ().getFacingSprite ("left");
		facingRight = manager.GetComponent<gameManagerScript> ().getFacingSprite ("right");
		manager.GetComponent<gameManagerScript> ().setLastPosition (level);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (checkWin()  == true) 
		{
			wonLevel ();
		}


		Vector3 currentPos = this.transform.position;

		if (Input.GetKeyDown ("space")) 
		{
			// shoot bullet
			// bullet should have velocity
			// bullet should shoot from player's right-ish side

			shootBullet ();
		}

		if (Input.GetKey("left")) 
		{
			currentPos.x -= playerSpeed;
			facing = "left";
			this.GetComponent<SpriteRenderer> ().sprite = facingLeft;
		}

		if (Input.GetKey("right"))
		{
			currentPos.x += playerSpeed;
			facing = "right";
			this.GetComponent<SpriteRenderer> ().sprite = facingRight;
		}

		if (Input.GetKey("up"))
		{
			currentPos.y += playerSpeed;
			facing = "up";
			this.GetComponent<SpriteRenderer> ().sprite = facingUp;
		}

		if (Input.GetKey("down"))
		{
			currentPos.y -= playerSpeed;
			facing = "down";
			this.GetComponent<SpriteRenderer> ().sprite = facingDown;
		}

		Destroy (this.gameObject.GetComponent<CircleCollider2D> ());
		this.gameObject.AddComponent<CircleCollider2D> ();
		this.transform.position = currentPos;
	}
}
