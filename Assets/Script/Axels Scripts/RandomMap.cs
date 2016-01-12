using UnityEngine;
using System.Collections.Generic;

public class RandomMap : MonoBehaviour {

	private float x;
	private float z;

	private float[] xies;
	private float[] zies;

	private Vector3[][] positions;
	private bool[][] arrayOfBoolArrays;

	// Use this for initialization
	void Awake () {

		xies = new float[40];
		zies = new float[40];
		arrayOfBoolArrays = new bool[40][];

		foreach(bool[] t in arrayOfBoolArrays)
		{
			bool[] boolArray = new bool[40];

			foreach(bool r in boolArray)
			{
				bool state = new bool();

				state = false;
			}
				
		}



		for(int i = 1; i < xies.Length; i++)
		{
			xies[i] = xies[i] + 2.0f;
			zies[i] = zies[i] + 2.0f;

		}

		positions = GenerateVector3(zies, xies);
	
	}
	void Start()
	{
		
	}
	private Vector3[][] GenerateVector3(float[] a, float[] b)
	{
		Vector3[][] posMatrix = new Vector3[40][];


		for(int i = 0; i < a.Length; i++)
		{
			Vector3[] newPosArray = new Vector3[a.Length];

			for(int t = 0; t < b.Length; t++)
			{
				Vector3 newPos = new Vector3(a[i], 0.0f, b[t]);

				newPosArray[i] = newPos;
			}

			posMatrix[i] = newPosArray;
			
		}

		return posMatrix;
	}
	private void GenerateColliders(Vector3[][] a)
	{

	}
	private bool IsBorder(Vector3 a)
	{
		if(a.x == 0.0f || a.z == 0.0f || a.x == 80.0f || a.z == 80.0f)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}