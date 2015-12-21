using UnityEngine;
using System.Collections;

public class TeleportOneWay : MonoBehaviour {

	public GameObject[] teleportEnterArray;
	public GameObject[] teleportExitArray;
	public GameObject pacmanMoveObject;
	//pacmanMove pacmanMoveScript;

	void Start () {
		//pacmanMoveScript = pacmanMoveObject.GetComponent<pacmanMove>();
	}
	public void TeleportPacman(GameObject theTeleport){
		for(int i = 0; i < teleportEnterArray.Length; i++){
			if(teleportEnterArray[i] == theTeleport){
				pacmanMoveObject.transform.position = teleportExitArray[i].gameObject.transform.position;
			}
		}
	}

}
