using UnityEngine;
using System.Collections;
//**************************************************************************************************
//Scriptet pacmans 4 box colliders. via ett Bool värde kontrollerar pacman om box slår i en vägg.
//**************************************************************************************************
public class boxMovement : MonoBehaviour {
	
	int inWall = 0;
	bool boxOK = true;
	
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Wall"){
			inWall = inWall +1;
		}
	}
	void OnTriggerExit(Collider trigger){
		if(trigger.gameObject.tag == "Wall"){
			inWall = inWall -1;
		}
	}
	public void SetWallZero(){
		inWall = 0;
		//Debug.Log("inwall " + gameObject.name + " " + inWall);
	}

//om InWall är = 0 returnerar BoxMovement värdet True till pacman
	public bool ReturnBoxOK(){
		if(inWall == 0){
			boxOK = true;
		}else{
			boxOK = false;
		}
		//Debug.Log(gameObject.name + " " + boxOK + "inWall = " + inWall);
		return boxOK;
	}
}
