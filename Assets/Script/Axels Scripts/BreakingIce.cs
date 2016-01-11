using UnityEngine;
using System.Collections;

public class BreakingIce : MonoBehaviour {

	//Detta script ska användas till att göra en plattform som "försvinner" efter att pacman gått över den två gånger. Jag räknar hur många gånger pacman har gått in i en viss collider.
	//När varibael timesPacHasEntered kommit upp i två kommer något att hända när pacMan lämnar collidern. Om Pacman går mot plattformen igen kommer han att ramla ner och dö. 

	private int timesPacHasEntered;  //Den variabel ska räkna hur många gånger pacman har gått över en platta.

	private GameObject iceTextureCube; //Objectet som ska byta texture.

	private Material crackedIce;
	private Material noIce;

	void Start () {
	
		gameObject.name = "Ice Mist";

		timesPacHasEntered = 0;



		iceTextureCube = this.gameObject.transform.GetChild(0).gameObject;

		crackedIce = Resources.Load("BrokenIce") as Material;
		noIce = Resources.Load("NoIce") as Material;
	}
		
		
	void OnTriggerExit(Collider col)
	{
			if(col.gameObject.tag == ("Pacman"))
			{

										timesPacHasEntered++;
									if(timesPacHasEntered == 3) //Dett händer om man gått av isbiten en gång.
									{
				
										gameObject.tag = "DropZone";

															
										iceTextureCube.GetComponent<MeshRenderer>().sharedMaterial = noIce;
										transform.GetChild(1).GetComponent<ParticleSystem>().Emit(500);

										

									}
			if(col.gameObject.tag == ("Pacman") && timesPacHasEntered == 1)  //Detta händer om man gått av isbiten andra gången.
			{
				iceTextureCube.GetComponent<MeshRenderer>().sharedMaterial = crackedIce;
				transform.GetChild(1).GetComponent<ParticleSystem>().Emit(50);
			}


	}
	}

}

