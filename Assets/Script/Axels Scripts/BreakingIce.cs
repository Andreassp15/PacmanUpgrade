using UnityEngine;
using System.Collections;

public class BreakingIce : MonoBehaviour {

	//Detta script ska användas till att göra en plattform som "försvinner" efter att pacman gått över den två gånger. Jag räknar hur många gånger pacman har gått in i en viss collider.
	//När varibael timesPacHasEntered kommit upp i två kommer något att hända när pacMan lämnar collidern. Om Pacman går mot plattformen igen kommer han att ramla ner och dö. 

	private int timesPacHasEntered;  //Den variabel ska räkna hur många gånger pacman har gått över en platta.

	//private GameObject pacMan;

	void Start () {
	
		timesPacHasEntered = 0;

		//pacMan = GameObject.Find

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == ("PacMan") && timesPacHasEntered != 2)
		{
			timesPacHasEntered++;
			Debug.Log("PacMan enters platform");
		}


	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag == ("PacMan"))
		{
			if(timesPacHasEntered == 2)
			{
				PacManFallnDie();
				Debug.Log("Oh No I fall and Die");
			}
				
		}
	}

	void PacManFallnDie()
	{
		
	}

}
