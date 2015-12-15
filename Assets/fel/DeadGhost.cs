using UnityEngine;
using System.Collections;

public class DeadGhost : MonoBehaviour {
//******************************************************************************'
//scriptet aktivers från GhostControl och används då spökerna är döda och flyr till sitt bo
//**********************************************************************

	public GameObject ghostNest;
	public GameObject ghostControl;
	public GhostControl GhostControlScript;

	void Start () {

		GhostControlScript = ghostControl.GetComponent<GhostControl>();
	}
	public void runNest(){
	gameObject.GetComponent<NavMeshAgent>().radius = 0;
	gameObject.GetComponent<NavMeshAgent>().SetDestination (ghostNest.transform.position);
	//sätter sin radie till 0 för att inte krocka med andra spöken
	//och rör sig därefter till boet
	}
	void OnTriggerEnter(Collider trigg){

		if(trigg.gameObject.tag == "nest"){
			StartCoroutine(huntTimer(5f));
			//när spöket nått boet väntar den 5 sekunder och talar sedan om för GhostControll att den är framme.
		}
	}
	IEnumerator huntTimer(float waitTime){
		yield return new WaitForSeconds(waitTime);
		GhostControlScript.arrivedAtNest(gameObject);
	}
}
