using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {

	public GameObject canonBallObject;
	CanonBallProjectile canonBallProjectileScript;
	float rotationDegreesPerSecond = 45f;
	Vector3 direction;
	float dY;

	void Start () {
		canonBallProjectileScript = canonBallObject.GetComponent<CanonBallProjectile>();
	}
	void myDirection(){
		dY = gameObject.transform.localEulerAngles.y;
		direction = new Vector3(gameObject.transform.localEulerAngles.x,gameObject.transform.localEulerAngles.y, gameObject.transform.localEulerAngles.z);
		//Debug.Log("direction");
		//canonBall.GetComponent<Rigidbody>().AddForce(direction * fireSpeed);
	}
	

	void Update () {
		RotationMethod();
		myDirection();
		
		if (Input.GetKeyDown(KeyCode.Space)){
			canonBallProjectileScript.ProjectileDirection(dY);
			
		}
	}
	void RotationMethod(){
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
	}
}
