using UnityEngine;
using System.Collections;
//------------------Programmerare Sp15 Ludvig Emtås-------------------
//*****************************************************************
// Scriptet Teleporterar pacman från Enter till Exit Object
//******************************************************************

public class TeleportOneWay : MonoBehaviour {

	public GameObject[] teleportEnterArray;
	public GameObject[] teleportExitArray;
	public GameObject audioPlayerObject;
	AudioPlayer audioPlayerScript;
	GameObject pacmanMoveObject;
	Transform pacmanObject;

	void Start () {
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
		pacmanMoveObject = GameObject.FindGameObjectWithTag("FindPacmanObject");
		pacmanObject = pacmanMoveObject.GetComponent<Transform>();
	}
	public void TeleportPacman(GameObject theTeleport){
		audioPlayerScript.PacmanteleportMethod();
		for(int i = 0; i < teleportEnterArray.Length; i++){
			if(teleportEnterArray[i] == theTeleport){
				pacmanMoveObject.transform.position = teleportExitArray[i].gameObject.transform.position;
			}
		}
	}

}
