using UnityEngine;
using System.Collections;

public class Activasion_Point : MonoBehaviour {


	private bool activated = false;


	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Pacman" && activated == false)
		{
			
			GetComponentInParent<Fire_Checkpoints>().AddPoint();	
			activated = true;
		}
		else if(activated == true && col.gameObject.tag == "Pacman")
		{

				GetComponentInParent<Fire_Checkpoints>().SubtractPoint();	
				activated = false;
			
		}
	}
}
