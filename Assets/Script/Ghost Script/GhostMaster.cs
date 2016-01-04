using UnityEngine;
using System.Collections;

public class GhostMaster : MonoBehaviour {

	public GameObject[] ghostArray;
	

	void Start () {
		HuntGhost();

	}
	public void HuntGhost(){
		for(int i = 0; i < ghostArray.Length; i++){
			ghostArray[i].gameObject.GetComponent<GhostDady>().ActivateHunt();
		}
	}
	public void EscapeGhost(){
		for(int i = 0; i < ghostArray.Length; i++){
			ghostArray[i].gameObject.GetComponent<GhostDady>().ActivateEscape();
		}
	}
	public void DeadGhost(GameObject theGhost){
		for(int i = 0; i < ghostArray.Length; i++){
			if(ghostArray[i] == theGhost.gameObject.transform.parent.gameObject){
				ghostArray[i].gameObject.GetComponent<GhostDady>().ActivateDead();
			}
		}
	}
	public void ResetGhost(){
		for(int i = 0; i < ghostArray.Length; i++){
			ghostArray[i].gameObject.GetComponent<GhostDady>().DeactivateAll();
			ghostArray[i].gameObject.GetComponent<GhostDady>().TeleportToNest();
		}
	}

	

	void Update () {
	
	}
}
