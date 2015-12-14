using UnityEngine;
using System.Collections;

public class EscapeGhost : MonoBehaviour {
//*******************************************************************************
//scriptet aktiveras från GhostControl och gör så att spökerna flyr från pacman
//******************************************************************************
	public AudioClip escapeSound;
	public AudioSource escapeSource;
	bool active = true;
	public Transform pacman;
	float distance = 20f;
	Vector3 escape;
	NavMeshAgent agent;

	void Start () {
		escapeSource.clip = escapeSound;
		agent = GetComponent<NavMeshAgent>();
		//spökerna spelar ett ljudslinga där de flyr
	}
	void Update () {
		if(active == true){
			runAway ();
		StartCoroutine(activateTrue());
			active = false;
		}
		//använder en bool som ser till att metoden runAway inte körs varje frame utan istället 1 gång varje sekund

	}
//--------------------------Run Opposite direction-----------
	void runAway(){
		escape = (pacman.position - transform.position).normalized;
		agent.destination = transform.position - escape * distance;
		//får spökerna att sfly i motsatt position jämfört med pacman
	}
//--------------------------aktivera True------------------
	IEnumerator activateTrue(){
		yield return new WaitForSeconds(1f);
		actTrue();
	}
//---------------act True används från GhostControl då scriptet activeras-------------
	public void actTrue(){
		active = true;
	}
}
