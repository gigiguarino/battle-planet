using UnityEngine;
using System.Collections;

public class rulesScript : MonoBehaviour 
{
	void Update()
	{
		if (Input.GetKey ("return")) 
		{
			Destroy (GameObject.Find ("cam"));
			Application.LoadLevel ("mainMenu");
		}
	}
}
