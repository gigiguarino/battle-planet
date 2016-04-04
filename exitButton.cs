using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class exitButton : MonoBehaviour {

	public Text exit;

	void OnMouseDown()
	{
		Application.Quit ();
	}

	void Start()
	{
		Vector3 pos = this.transform.position;
		pos.y += 0.17f;
		exit.transform.position = pos;
	}
}
