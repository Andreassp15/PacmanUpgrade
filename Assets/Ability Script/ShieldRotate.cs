using UnityEngine;
using System.Collections;

public class ShieldRotate : MonoBehaviour {

	float rotationDegreesPerSecond = 360f;
	void Start () {
	
	}

	void Update () {
		rotationMethod();
	}
	void rotationMethod()
	{   
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
		
	}
}
