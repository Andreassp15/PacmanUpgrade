using UnityEngine;
using System.Collections;

public class TeleportOneWay : MonoBehaviour {

	public GameObject[] teleportEnterArray;
	public GameObject[] teleportExitArray;
	GameObject pacmanMoveObject;
	Transform pacmanObject;
	//pacmanMove pacmanMoveScript;

	void Start () {
		pacmanMoveObject = GameObject.FindGameObjectWithTag("FindPacmanObject");
		pacmanObject = pacmanMoveObject.GetComponent<Transform>();
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
