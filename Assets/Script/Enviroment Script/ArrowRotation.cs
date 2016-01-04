using UnityEngine;
using System.Collections;

public class ArrowRotation : MonoBehaviour {

	// Use this for initialization
	Vector3 startRotation;
	float rotationDegreesPerSecond = 360f;
	void Start () {

	}

	void FixedUpdate () {
		rotationMethod();
	}
	void rotationMethod()
	{   
		Debug.Log("hehe");
		float currentAngle = transform.rotation.eulerAngles.z;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.forward);

	}
}
