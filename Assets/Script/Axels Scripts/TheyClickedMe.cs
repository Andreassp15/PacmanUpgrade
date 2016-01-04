using UnityEngine;
using System.Collections;

public class TheyClickedMe : MonoBehaviour {

	private GameObject canvas;

	void Start()
	{
		canvas = GameObject.Find("Canvas");
	}

	public void Clicked()
	{



		canvas.GetComponent<ValAvBana>().WhoIsClicked(gameObject.name);
	}
}
