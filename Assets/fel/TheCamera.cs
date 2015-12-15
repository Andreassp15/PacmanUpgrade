using UnityEngine;
using System.Collections;

public class TheCamera : MonoBehaviour {

	//public GameObject cameraLookAt;
	public Transform target;

	
	// Use this for initialization
	void Start () {
		

	}

	void Update(){

	
	}
	
	void LateUpdate () {
		//transform.position = cameraLookAt.transform.position.y + 8.5f;
		//transform.LookAt(cameraLookAt.gameObject.transform.position);
		transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z -4f);
	}
}

