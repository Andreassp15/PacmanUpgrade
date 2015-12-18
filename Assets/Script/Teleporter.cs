using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public GameObject[] enterArray;
	public GameObject[] exitArray;
	public Transform pacmanObject;

	//public GameObject connectorObject;
	//Connector connectorScript;
	void Start () {
		//connectorScript = connectorObject.GetComponent<Connector>();

	
	}
	void FindTeleports(){
		//enterArray = GameObject.FindGameObjectsWithTag("Teleport");
		//exitArray = GameObject.FindGameObjectsWithTag("TeleportExit");
	}
	public void TeleportPacman(GameObject theTeleport){
		for(int i = 0 ; i < enterArray.Length; i++){
			if(enterArray[i].gameObject == theTeleport){
				//int randomExit = Random.Range(0, exitArray.Length);
				for(int y = 0; y < exitArray.Length; y++){
					if(i == y){
						pacmanObject.transform.position = exitArray[i].gameObject.transform.position;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
