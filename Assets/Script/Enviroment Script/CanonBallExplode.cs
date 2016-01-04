using UnityEngine;
using System.Collections;

public class CanonBallExplode : MonoBehaviour {

	public GameObject explosion;
	public GameObject canonDaddyObject;
	CanonDaddy canonDaddyScript;



	void Start () {
		canonDaddyScript = canonDaddyObject.GetComponent<CanonDaddy>();
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag != "OrbBoss"){
			canonDaddyScript.CanonBallHitSomething(gameObject);
			WaitExplode();
		}

	}
	void WaitExplode(){
		StartCoroutine(ExplosiveTimer());
	}
	IEnumerator ExplosiveTimer(){
		yield return new WaitForSeconds(2f);
		canonDaddyScript.CancelExplosive(gameObject);
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		gameObject.SetActive(false);
	}

}
