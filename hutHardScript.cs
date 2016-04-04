using UnityEngine;
using System.Collections;

public class hutHardScript : MonoBehaviour 
{
	public GameObject enemy;
	float timeDelay = 8;
	float timeOfLastBullet;
	bool begin;

	int numBullets;
	int numBulletsToDie = 10;

	// Use this for initialization
	void Start () 
	{
		numBullets = 0;
		timeOfLastBullet = 0;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "bullet") 
		{
			numBullets += 1;
			Destroy (collider.gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (Time.time - timeOfLastBullet >= timeDelay) 
		{
			Vector3 pos = this.transform.position;

			if (pos.x < 0)
			{
				pos.y -= 1;
				pos.x += 1;
			}

			else if (pos.x > 0)
			{
				pos.y -= 1;
				pos.x -= 1;
			}

			else
			{
				pos.y -= 1;
			}

			GameObject newEnemy = Instantiate (enemy, pos, Quaternion.identity) as GameObject;
			timeOfLastBullet = Time.time;
		}

		if (numBullets >= numBulletsToDie) 
		{
			this.gameObject.SetActive (false);
		}
	}
}
