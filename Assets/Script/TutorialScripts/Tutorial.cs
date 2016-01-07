using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject path;
	GameObject[] goldArray;

	void Start () {
	
	}
	void FindGold(){
		goldArray = GameObject.FindGameObjectsWithTag("Gold");
	}
	

	void Update () {
	
	}
}
