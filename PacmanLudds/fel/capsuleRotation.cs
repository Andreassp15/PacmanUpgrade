using UnityEngine;
using System.Collections;
public class capsuleRotation : MonoBehaviour {
//********************************************************************************
//scriptet ä till fär att ge lite rörlse till de object pacman ska sammla
//********************************************************************************
	float rotationDegreesPerSecond = 180f;
	Vector3 myStartRotation = new Vector3(0f, 0f, 0f);
	public float myStartHeight;
	float floatSpeed = 0.1f;
	float floatHeight = 0.1f;

	//mystartheight ligger som public för att flera objekt i spelet använder sig av scriptet men har inte samma höjd.
	
	void Start () {
		myStartRotation.y = Random.Range(0f, 360f);
		transform.Rotate(myStartRotation);
	}
	void Update () {
		rotationMethod();
		upAndDown();
	}
//---------------------------Rotation--------------------------------
	void rotationMethod()
	{   
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
		//obejktet roterar runt sin egen axel
	}
//---------------------------Up and Down-----------------------------
	void upAndDown(){
		transform.position = new Vector3(transform.position.x, (myStartHeight + Mathf.PingPong(Time.time * floatSpeed, floatHeight)), transform.position.z);
		//objeet guppar upp och ner 
	}
}