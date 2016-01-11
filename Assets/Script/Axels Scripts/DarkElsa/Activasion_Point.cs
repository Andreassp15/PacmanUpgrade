using UnityEngine;
using System.Collections;

public class Activasion_Point : MonoBehaviour {


	private bool activated = false;

	private int myNr;

	void Start()
	{
		for(int i = 0; i < transform.parent.childCount; i++)
		{
			string name;

				name = transform.parent.GetChild(i).name;
			if(name == gameObject.name)
			{
				myNr = i;
			}
		}
	}


	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Pacman" && activated == false)
		{
			
			GetComponentInParent<Fire_Checkpoints>().AddPoint(myNr);	
			activated = true;
		}

	}
}
