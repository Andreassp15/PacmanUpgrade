using UnityEngine;
using System.Collections;

public class ArrowProjectile : MonoBehaviour {

	Vector3 direction;
	float moveSpeed = 0.1f;
	public float x;
	public float y;
	public float z;

	void Start () {
	
	}
	

	void FixedUpdate () {
		direction = new Vector3(x, y, z); 
		transform.Translate(direction * moveSpeed);
	}
	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag == "Pacman" || trigger.gameObject.tag == "Wall"){
			gameObject.SetActive(false);
		}

	}
}
