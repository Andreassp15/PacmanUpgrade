using UnityEngine;
using System.Collections;

public class DecoyExplosion : MonoBehaviour {

	public GameObject connectorObject;

	Connector connectorScript;

	void Start () {
		connectorScript = connectorObject.GetComponent<Connector>();
	
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "GhostHunt" || trigger.gameObject.tag == "GhostFlee"){
			connectorScript.PoweredAbilityHitSomething(trigger.gameObject);
		}
	}

}
