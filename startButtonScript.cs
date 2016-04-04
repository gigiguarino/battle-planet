using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startButtonScript : MonoBehaviour {

	public Text start;

	void Start()
	{
		Vector3 pos = this.transform.position;
		pos.y += 0.06f;
		start.transform.position = pos;
	}

	void OnMouseDown()
	{
		Application.LoadLevel ("playerChoose");
	}
}
