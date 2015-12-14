using UnityEngine;
using System.Collections;

public class myCamera : MonoBehaviour
{
//*************************************************************************
//scriptet sitter på kameran och följer efter pacman
//**********************************************************************
	public Transform target;			
	float camDistance = 4f;   			
	float camHeight = 1.5f;						
	float camHeightDamping = 2.0f;
	float camRotationDamping = 3f;
	
	void LateUpdate()
	{
		float getRotationAngle = target.eulerAngles.y;    //getRotationAngle = pacman y vinkel
		float getHeight = target.position.y + camHeight;	//getHeight = pacmany postion adderat med camheight
		float currentRotationAngle = transform.eulerAngles.y; //currentRotationAngle = kamerans y vinkel
		float currentHeight = transform.position.y;			//currentHeight = kamerans y position
		
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, getRotationAngle, camRotationDamping * Time.deltaTime);
		currentHeight = Mathf.Lerp(currentHeight, getHeight, camHeightDamping * Time.deltaTime);
		//currentRotationAngle följer pacmansvinkel via Lerp
		//currentHeight följer pacmans höjd via Lerp
		Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * camDistance;
		//flyttar kameran efter pacman
		
		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
		transform.LookAt(target);
		//kameran kollar på pacman
	}

}