using UnityEngine;
using System.Collections;

public class ZoneTwo : MonoBehaviour {

	public GameObject bossDeactivated;
	public GameObject bossActivated;
	public bool zoneTwo;


	public void Start()
	{
		zoneTwo = false;
	}

	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			zoneTwo = true;
			bossActivated.SetActive (true);
			bossDeactivated.SetActive (false);
			//			Debug.Log ("Enter");
		}

	}

	void OnTriggerExit (Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			zoneTwo = false;
			bossActivated.SetActive (false);
			bossDeactivated.SetActive (true);
			//			Debug.Log ("Exit");
		}
	}


}