using UnityEngine;
using System.Collections;

public class bossHutScript1 : MonoBehaviour 
{
	public GameObject enemy;
	float timeDelay = 6;
	float timeOfLastBullet;

	int numBullets;
	int numBulletsToDie = 4;

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
			Debug.Log (numBullets);
			numBullets += 1;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time - timeOfLastBullet >= timeDelay) {
			Vector3 pos = this.transform.position;
			pos.y -= 2;
			pos.x -= 1;
			GameObject newEnemy = Instantiate (enemy, pos, Quaternion.identity) as GameObject;
			timeOfLastBullet = Time.time;
		}

		if (numBullets >= numBulletsToDie) 
		{
			this.gameObject.SetActive (false);
		}
	}
}
