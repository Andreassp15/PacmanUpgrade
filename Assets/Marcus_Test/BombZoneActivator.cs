using UnityEngine;
using System.Collections.Generic;

//*******//Main Zone Script//*******//

public class BombZoneActivator : MonoBehaviour
{


	public GameObject bossActivated;
	NewBossEvent bossScript;


	void Start ()
	{
		bossScript = bossActivated.GetComponent<NewBossEvent> ();
	}

	public void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			bossScript.ZoneActivated (gameObject);
			Debug.Log("Collided with the bomb zone");
		}

	}


}