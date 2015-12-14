using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	Vector3 direction;
	float moveSpeed = 0.1f;


	void Start () {
	
	}
	

	void Update () {
		direction = new Vector3(0, -1, 0); 
		transform.Translate(direction * moveSpeed);
	}
	void OnTriggerEnter(Collider trigger){
		gameObject.GetComponent<SphereCollider>().radius = 2;
		gameObject.SetActive(false);
	}
}
