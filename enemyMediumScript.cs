using UnityEngine;
using System.Collections;

public class enemyMediumScript : MonoBehaviour 
{
	GameObject player;

	AudioClip clip;

	public Sprite up;
	public Sprite down;
	public Sprite left;
	public Sprite right;

	float enemySpeed = 0.02f;
	int numBulletsToKill = 1; 

	int numBullets;

	public void Hit(Collider2D collider)
	{
		numBullets += 1;

		if (numBullets >= numBulletsToKill) 
		{
			Destroy (collider.gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		this.GetComponent<Rigidbody2D> ().freezeRotation = true;
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 playerPos = player.transform.position;
		Vector3 enemyPos = this.transform.position;

		float displacementX = playerPos.x - enemyPos.x;
		float displacementY = playerPos.y - enemyPos.y;

		if (Mathf.Abs(displacementX) > Mathf.Abs(displacementY)) 
		{
			if (displacementX < 0) 
			{
				this.GetComponent<SpriteRenderer> ().sprite = left;
				enemyPos.x -= enemySpeed;

				if (displacementY < 0) 
				{
					enemyPos.y -= enemySpeed;
				} 

				else if (displacementY > 0)
				{
					enemyPos.y += enemySpeed;
				}
			} 

			else 
			{
				this.GetComponent<SpriteRenderer> ().sprite = right;
				enemyPos.x += enemySpeed;

				if (displacementY < 0) 
				{
					enemyPos.y -= enemySpeed;
				} 

				else if (displacementY > 0)
				{
					enemyPos.y += enemySpeed;
				}
			}
		} 

		else 
		{
			if (displacementY > 0) 
			{
				this.GetComponent<SpriteRenderer> ().sprite = up;
				enemyPos.y += enemySpeed;

				if (displacementX < 0)
				{
					enemyPos.x -= enemySpeed;
				}

				else if (displacementX > 0)
				{
					enemyPos.x += enemySpeed;
				}
			} 

			else if (displacementY < 0) 
			{
				this.GetComponent<SpriteRenderer> ().sprite = down;
				enemyPos.y -= enemySpeed;

				if (displacementX < 0)
				{
					enemyPos.x -= enemySpeed;
				}

				else if (displacementX > 0)
				{
					enemyPos.x += enemySpeed;
				}
			} 

			else 
			{
				if (displacementY > 0) 
				{
					enemyPos.y += enemySpeed;
				} 

				else 
				{
					enemyPos.y -= enemySpeed;
				}
			}
		}

		Destroy (this.gameObject.GetComponent<PolygonCollider2D> ());
		this.gameObject.AddComponent<PolygonCollider2D> ();
		this.transform.position = enemyPos;
	}
}
