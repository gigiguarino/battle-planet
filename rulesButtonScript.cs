using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rulesButtonScript : MonoBehaviour 
{
	public Text rulesText;

	void OnMouseDown()
	{
		Application.LoadLevel ("rules");
	}

	// Use this for initialization
	void Start () 
	{
		Vector3 pos = this.transform.position;
		pos.y += 0.055f;
		rulesText.transform.position = pos;
	}
}
