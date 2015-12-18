using UnityEngine;
using System.Collections;

public class ZoneOne : MonoBehaviour {

	public GameObject bossDeactivated;
	public GameObject bossActivated;
	BossEvent bossScript;
	public bool zoneOne;

	//Gör det i en array, med dem olika zonerna och använd ett script.


	public void Start()
	{
		bossScript = bossActivated.GetComponent<BossEvent> ();
		zoneOne = false;
	}

	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			zoneOne = true;
			bossScript.zoonOneTrue ();
			bossActivated.SetActive (true);
			bossDeactivated.SetActive (false);
//			Debug.Log ("Enter");
		}
	
	}

	void OnTriggerExit (Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			zoneOne = false;
			bossActivated.SetActive (false);
			bossDeactivated.SetActive (true);
//			Debug.Log ("Exit");
		}
	}
	

}