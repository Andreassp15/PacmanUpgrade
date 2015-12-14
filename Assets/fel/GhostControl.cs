using UnityEngine;
using System.Collections;

public class GhostControl : MonoBehaviour {
//****************************************************************************'
//scriptet håller redan på alla spöken i form av arrayer
//***********************************************************************

	public GameObject [] ghostArray;
	public GameObject [] deadArray;
	public GameObject [] escapeArray;
	public GameObject nest;

	int ghostAmount = 0;

	void Start () {
		InvokeRepeating("startGhost", 0, 0.5f);
	
	}
//------------------Ghost Spawn----------------------------
	void startGhost(){
		if(ghostAmount < ghostArray.Length){
			ghostArray[ghostAmount].SetActive (true);
			ghostArray[ghostAmount].GetComponent<HuntGhost>().resetHunt();
			ghostAmount = ghostAmount +1;
		}else{
			CancelInvoke("startGhost");
			ghostAmount = 0;
		}
		//använder arrayen för att gå igenom spökerna
	}
//-------------------Activate Ghost Escape--------------------------
	public void activateEscape(){	
		for(int i = 0; i < ghostArray.Length ; i++){
			if(ghostArray[i].activeSelf){
				ghostArray[i].SetActive (false);
				escapeArray[i].transform.position = ghostArray[i].transform.position;
				escapeArray[i].SetActive (true);
				escapeArray[i].GetComponent<EscapeGhost>().actTrue();
			}		
		}// avktiverar gameobjectet på det jagande spöket. teleporterar dessa escape form till
		//dennes posiviton och aktiverar sedan escape.
	}
//------------------Deactivate Ghost Escape--------------------------
	public void deactivateEscape(){
		for(int i = 0; i < escapeArray.Length ; i++){
			if(escapeArray[i].activeSelf){
				escapeArray[i].SetActive(false);
				ghostArray[i].transform.position = escapeArray[i].transform.position;
				ghostArray[i].SetActive (true);
			}
		}// kontrollerar om escape är aktivt isåfall byt till jaga
	}
//-------------------Activate Ghost Dead------------------------------
	public void activateDead(GameObject whatGhost){
		for(int i = 0; i < escapeArray.Length; i++){	
			if (escapeArray[i] == whatGhost){
				escapeArray[i].SetActive(false);
				for(int j = 0; j < deadArray.Length; j++){
					if(i == j){
						deadArray[j].transform.position = escapeArray[i].transform.position;
						deadArray[j].SetActive(true);
						deadArray[j].GetComponent<DeadGhost>().runNest();
						
					}
				}
			}
		}//kollar vilket spöke som dött och aktiverar därefter dess döda form
	}
//-------------------Ghost Arrived to Nest----------------------------
	public void arrivedAtNest(GameObject whatGhost){
		for(int i = 0; i < deadArray.Length; i++){	
			if (deadArray[i] == whatGhost){
				deadArray[i].SetActive(false);
				for(int j = 0; j < ghostArray.Length; j++){
					if(i == j){
						ghostArray[j].transform.position = deadArray[i].transform.position;
						ghostArray[j].SetActive(true);
					}
				}
			}
		}// kontrollerar vilekt object som är i boet och aktiverar därfter jaga på det spöket
	}
//-----------------------Restart Ghost-----------------------------------
	public void resetGhost(){
		for(int i = 0; i < ghostArray.Length; i++){
			ghostArray[i].SetActive(false);
			escapeArray[i].SetActive(false);
			deadArray[i].SetActive(false);
			ghostArray[i].transform.position = nest.transform.position;
		}
		InvokeRepeating("startGhost", 3, 0.5f);
		//återställer alla spöken 
	}

}
