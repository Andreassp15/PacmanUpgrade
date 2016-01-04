using UnityEngine;
using System.Collections;

public class ArrowSpawn : MonoBehaviour {

	public GameObject[] arrowArray;
	int theArrow = 0;
	public float fireRate;
	public float waitTime;

	void Start () {
		InvokeRepeating("FireArrow", waitTime, fireRate);
	
	}

	void FireArrow(){
		arrowArray[theArrow].gameObject.transform.position = transform.position;
		arrowArray[theArrow].gameObject.SetActive(true);
		if(theArrow < arrowArray.Length -1){
			theArrow = theArrow +1;
		}else{
			theArrow = 0;
		}


	}
	void Update () {
	
	}
}
