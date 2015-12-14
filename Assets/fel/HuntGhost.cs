using UnityEngine;
using System.Collections;

public class HuntGhost : MonoBehaviour {
//******************************************************************************
//aktiveras från GhostControl. är til för att spökerna ska jaga pacman
//**************************************************************************

	bool huntPoint = true;
	public GameObject pacman;
	public AudioClip huntSound;
	public AudioSource huntSource;

	public GameObject myPoint;

	void Update () {

		hunt();
		//huntmetoden körs i uppdate

	}
	void Start(){
		huntSource.clip = huntSound;

	}

	void hunt(){
		if(huntPoint == true){
			gameObject.GetComponent<NavMeshAgent>().SetDestination(myPoint.transform.position);
		}	
		else{
			gameObject.GetComponent<NavMeshAgent>().SetDestination (pacman.transform.position);
		}
		//om huntPoint är true tar sig spöket till den förbestmda punkten
		// annars jagar den pacman
	}
	void OnTriggerEnter(Collider trigg){
		if(trigg.gameObject.tag == "ghostPoint"){
			huntPoint = false;
			//huntpoint blir false då spöket år sin punkt
		}

	}	
	public void resetHunt(){
		huntPoint = true;
		//körs från ghostControl varje gång spökerna resetas ( tex då spelet startar om eller pacman dör)
	}

}
