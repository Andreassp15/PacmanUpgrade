using UnityEngine;
using System.Collections;

public class TeleportAgent : MonoBehaviour {

	public GameObject pointObject;
	Vector3 point;
	float x;
	float z;

	void Start () {
		InvokeRepeating("RandomPoint", 0, 10);
	
	}
	
	void RandomPoint(){
		x = Random.Range(-12, 12);
		z = Random.Range(-12, 12);
		point = new Vector3( x, 0, z);
		pointObject.transform.position = point;
	}
	void Update () {
		gameObject.GetComponent<NavMeshAgent>().SetDestination (pointObject.transform.position);
	}
}
