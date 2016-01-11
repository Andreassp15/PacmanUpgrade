using UnityEngine;
using System.Collections.Generic;

//*******//Main Zone Script//*******//

public class BombZoneActivator : MonoBehaviour
{

	//This script is here to tell the boss when the player enters one of the eight zones that the boss will throw a bomb towrds.
	//This is also linked to the boss script so it cand deliver the bomb zones value to the boss script so it will know where to throw the bomb.
	public GameObject bossActivated;
	NewBossEvent bossScript;

	//Gets the boss script from the boss so it can be used in this script.
	void Start ()
	{
		bossScript = bossActivated.GetComponent<NewBossEvent> ();
	}

	//Here we check what entered the zone, or rather we check if what enterd had the tag "Pacman", if i does then send the zones value to the boss script that will
	//then deal with it and throw the bomb.
	public void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Pacman") 
		{
			bossScript.ZoneActivated (gameObject);
			Debug.Log("Collided with the bomb zone");
		}

	}


}