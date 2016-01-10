using UnityEngine;
using System.Collections;

public class CoinsTuto : MonoBehaviour {

	public GameObject[] moveGoldArray;
	public GameObject[] positionsShiled;
	public GameObject[] positionsMagnet;
	public GameObject[] positionsDecoy;

	void Start () {
	
	}
	public void WhatPacman(GameObject thePacman){
		if(thePacman.gameObject.transform.parent.gameObject.name == "PacmanKai"){
			for(int i = 0 ; i < moveGoldArray.Length; i++){
					for(int j = 0 ; j < positionsShiled.Length; j++){
						if(i == j){
							moveGoldArray[i].transform.position = positionsShiled[j].transform.position;
						}
					}
				}
		}else if(thePacman.gameObject.transform.parent.gameObject.name == "PacmanJon"){
			for(int i = 0 ; i < moveGoldArray.Length; i++){
				for(int j = 0 ; j < positionsMagnet.Length; j++){
					if(i == j){
						moveGoldArray[i].transform.position = positionsMagnet[j].transform.position;
					}
				}
			}
		}else if(thePacman.gameObject.transform.parent.gameObject.name == "PacmanNicklas"){
			for(int i = 0 ; i < moveGoldArray.Length; i++){
				for(int j = 0 ; j < positionsDecoy.Length; j++){
					if(i == j){
						moveGoldArray[i].transform.position = positionsDecoy[j].transform.position;
					}
				}
			}
		}
	}

	void Update () {
	
	}
}
