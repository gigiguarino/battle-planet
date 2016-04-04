using UnityEngine;
using System.Collections;

public class playerChooseHoverScript : MonoBehaviour {

	public Sprite graySprite;
	public Sprite colorSprite;

	public GameObject manager;

	public int playerNum;

	void OnMouseEnter()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = colorSprite;
	}

	void OnMouseOver()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = colorSprite;
	}

	void OnMouseExit()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = graySprite;
	}

	void OnMouseDown()
	{
		manager.GetComponent<gameManagerScript> ().setPlayerNum (playerNum);
		manager.GetComponent<gameManagerScript> ().setCurrentLevel (0);
		manager.GetComponent<gameManagerScript> ().setNumLives ();
		Application.LoadLevel ("levelMap");
	}

	void Start()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = graySprite;
	}
}
