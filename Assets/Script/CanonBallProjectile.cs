using UnityEngine;
using System.Collections;

public class CanonBallProjectile : MonoBehaviour {

	Vector3 direction;
	float fireSpeed = 0.01f;
	bool fire = false;
	float dX;


	void Start () {
	
	}
	public void ProjectileDirection(float theDirection){
		Debug.Log ("vector" + theDirection);
		fire = true;
		dX = theDirection;
		direction = new Vector3(dX, dX, 0);
	}

	void Update () {
		if(fire == true){
			gameObject.GetComponent<Rigidbody>().AddForce(direction * fireSpeed);
		}
	}
	void OnTriggerEnter(Collider trigger){
		fire = false;
	}
}
