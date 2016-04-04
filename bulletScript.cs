using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour 
{

	public AudioClip bulletNoise;

	void Awake()
	{
		AudioSource.PlayClipAtPoint (bulletNoise, this.transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "planet" ||
			collider.gameObject.tag == "bullet") 
		{
			Destroy(GameObject.Find("bulletPrefab(Clone)"));
		}

		if (collider.gameObject.tag == "enemyEasy") 
		{
			collider.gameObject.GetComponent<enemyEasyScript> ().Hit (collider);
			Destroy (GameObject.Find ("bulletPrefab(Clone)"));
		}

		if (collider.gameObject.tag == "enemyMedium") 
		{
			collider.gameObject.GetComponent<enemyMediumScript> ().Hit (collider);
			Destroy (GameObject.Find ("bulletPrefab(Clone)"));
		}

		if (collider.gameObject.tag == "enemyHard") 
		{
			collider.gameObject.GetComponent<enemyHardScript> ().Hit (collider);
			Destroy (GameObject.Find ("bulletPrefab(Clone)"));
		}

		if (collider.gameObject.tag == "boss1") 
		{
			collider.gameObject.GetComponent<bossScript1> ().Hit (collider);
			Destroy (GameObject.Find ("bulletPrefab(Clone)"));
		}

		if (collider.gameObject.tag == "finalBoss") 
		{
			collider.gameObject.GetComponent<finalBossBattleScript> ().Hit (collider);
			Destroy(GameObject.Find ("bulletPrefab(Clone)"));
		}
	}
}
