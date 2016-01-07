using UnityEngine;
using System.Collections;
//*************************************************************'
//Pacmans box Collider. används då pacman colliderar med object
//*************************************************************
public class pacmanCollider : MonoBehaviour {


	public GameObject connectorObject;
	Connector connectorScipt;

	void Start () {
		connectorScipt = connectorObject.GetComponent<Connector>();
	}
//-------------------------OnTriggerEnter-----------------------------------
	void OnTriggerEnter(Collider trigger){
		//skickar objectet till Connector som kollar tag och vad som händer
		GameObject sendObject = trigger.gameObject;
		connectorScipt.pacmanHitSomething(sendObject);
	}

}
