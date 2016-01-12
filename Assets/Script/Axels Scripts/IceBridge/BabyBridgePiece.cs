using UnityEngine;
using System.Collections.Generic;

public class BabyBridgePiece : MonoBehaviour { //

	private FloatingBridges mama;


	private int whoAmI;

	private string myName;

		void Start () {

		mama = gameObject.transform.parent.GetComponent<FloatingBridges>();

		whoAmI = 0;

		myName = gameObject.name;

		for(int i = 0; i < gameObject.transform.parent.gameObject.transform.childCount; i++)
		{
			string heyThatsMe;

			heyThatsMe = gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject.name;

			if(heyThatsMe == myName)
			{
				whoAmI = i;
			}

		}
	}
		

	void OnTriggerExit(Collider col)
	{
		
		if(col.gameObject.tag == ("Pacman"))
		{
			mama.LetItFall(whoAmI);
			mama.SetPacmanInAir(false);
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == ("Pacman"))
		{
			mama.SetPacmanInAir(true);
		}
	}
}
