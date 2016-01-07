using UnityEngine;
using System.Collections;
public class capsuleRotation : MonoBehaviour {
//------------------Programmerare Sp15 Ludvig Emtås-------------------
//********************************************************************************
//scriptet ä till fär att ge lite rörlse till de object pacman ska sammla
//********************************************************************************
	float rotationDegreesPerSecond = 90f;
	Vector3 myStartRotation = new Vector3(0f, 0f, 0f);
	bool flyToPacman = false;
	bool up = true;
	bool flyUP = true;
	GameObject pacman;
	float collectSpeed = 2f;


	
	void Start () {
		myStartRotation.y = Random.Range(0f, 360f);
		transform.Rotate(myStartRotation);
	}
	void FixedUpdate () {
		rotationMethod();
		if(flyToPacman == true){
			gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.transform.position, pacman.transform.position, collectSpeed * Time.deltaTime);
			StartCoroutine(upAndDown());
			if(flyUP == true){
				if(up == true){
					gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +1f, gameObject.transform.position.z), collectSpeed * Time.deltaTime);
				}else{
					gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -1f, gameObject.transform.position.z), collectSpeed * Time.deltaTime);
				}
			}
		}
	}
	IEnumerator upAndDown(){
		yield return new WaitForSeconds(1f);
		up = false;
		yield return new WaitForSeconds(0.5f);
		flyUP = false;
	}

//---------------------------Rotation--------------------------------
	void rotationMethod()
	{   
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
		//obejktet roterar runt sin egen axel
	}
	public void FlyToPacmanMethod(GameObject thePacman){
		pacman = thePacman;
		flyToPacman = true;
	}


}