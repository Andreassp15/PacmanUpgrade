using UnityEngine;
using System.Collections;

public class BreakingIce : MonoBehaviour {

	//Detta script ska användas till att göra en plattform som "försvinner" efter att pacman gått över den två gånger. Jag räknar hur många gånger pacman har gått in i en viss collider.
	//När varibael timesPacHasEntered kommit upp i två kommer något att hända när pacMan lämnar collidern. Om Pacman går mot plattformen igen kommer han att ramla ner och dö. 

	private int timesPacHasEntered;  //Den variabel ska räkna hur många gånger pacman har gått över en platta.

	private GameObject iceTextureCube; //Objectet som ska byta texture.

	private Material crackedIce;
	private Material brokenIce;

	void Start () {
	
		timesPacHasEntered = 0;



		iceTextureCube = this.gameObject.transform.GetChild(0).gameObject;

		crackedIce = Resources.Load("Ice") as Material;
		brokenIce = Resources.Load("BrokenIce") as Material;
	}

	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{

		if(col.gameObject.tag == ("Pacman") && timesPacHasEntered != 2) //räknar hur många gånger pacman gått på en isbit.
		{
			
			timesPacHasEntered++;


		}


	}

	void OnTriggerExit(Collider col)
	{
			if(col.gameObject.tag == ("Pacman"))
			{



									if(timesPacHasEntered == 2) //Dett händer om man gått av isbiten en gång.
									{
										gameObject.tag = "DropZone";

										transform.localScale.Scale(new Vector3(.1f, 1f, .1f));
															
										iceTextureCube.GetComponent<MeshRenderer>().sharedMaterial = brokenIce;
										transform.GetChild(1).GetComponent<ParticleSystem>().Emit(500);

									}
			if(col.gameObject.tag == ("Pacman") && timesPacHasEntered == 1)  //Detta händer om man gått av isbiten andra gången.
			{
				iceTextureCube.GetComponent<MeshRenderer>().sharedMaterial = crackedIce;
				transform.GetChild(1).GetComponent<ParticleSystem>().Emit(250);
			}

	}
	}

}

