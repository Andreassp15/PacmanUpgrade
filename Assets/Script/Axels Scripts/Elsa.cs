using UnityEngine;
using System.Collections.Generic;

public class Elsa : MonoBehaviour {

	public GameObject[] jumpPoints;
	public GameObject[] airPoints;
	private Vector3[] jumpPointsPositions;
	private Vector3[] airPointsPositions;

	void Start () {

		jumpPoints = new GameObject[4];
		jumpPointsPositions = new Vector3[4];
		airPoints = new GameObject[5];
		airPointsPositions = new Vector3[5];

		for(int i = 0; i < 4; i++)
		{
			jumpPointsPositions[i] = jumpPoints[i].transform.position;
			airPointsPositions = airPoints[i].transform.position;
		}
	}

	void Update () {
	
	}

	void JumpUp(Vector3 to)
	{
		transform.position = Vector3.Lerp(transform.position,)
	}
}
