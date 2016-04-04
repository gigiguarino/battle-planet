using UnityEngine;
using System.Collections;

public class hutEasyScript : MonoBehaviour 
{
	public GameObject enemy;
	float timeDelay = 3;
	float timeOfLastBullet;

	int numBullets;
	int numBulletsToDie = 3;

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
			pos.y -= 1;
			GameObject newEnemy = Instantiate (enemy, pos, Quaternion.identity) as GameObject;
			timeOfLastBullet = Time.time;
		}

		if (numBullets >= numBulletsToDie) 
		{
			this.gameObject.SetActive (false);
		}
	}
}
