using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playAgainButton : MonoBehaviour 
{
	public Text playAgain;

	void OnMouseDown ()
	{
		Destroy (GameObject.Find ("cam"));
		Application.LoadLevel("mainMenu");
	}
		
	void Start()
	{
		Vector3 pos = this.transform.position;
		pos.y += 0.2f;
		playAgain.transform.position = pos;
	}

}
