using UnityEngine;
using System.Collections;
public class capsuleRotation : MonoBehaviour {
//********************************************************************************
//scriptet ä till fär att ge lite rörlse till de object pacman ska sammla
//********************************************************************************
	float rotationDegreesPerSecond = 90f;
	Vector3 myStartRotation = new Vector3(0f, 0f, 0f);


	
	void Start () {
		myStartRotation.y = Random.Range(0f, 360f);
		transform.Rotate(myStartRotation);
	}
	void FixedUpdate () {
		rotationMethod();
	}
//---------------------------Rotation--------------------------------
	void rotationMethod()
	{   
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
		//obejktet roterar runt sin egen axel
	}


}