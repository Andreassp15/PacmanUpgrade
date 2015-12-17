using UnityEngine;
using System.Collections.Generic;

//*******//Main Zone Script//*******//

public class BombZoneActivator : MonoBehaviour
{


	public GameObject bossActivated;
		NewerBossEvent bossScript;


	void Start ()
	{
		bossScript = bossActivated.GetComponent<NewerBossEvent> ();
	}

	public void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			bossScript.ZoneActivated (transform.position);
			bossActivated.SetActive (true);
			Debug.Log("Collided with the bomb zone");
		}

	}


}
