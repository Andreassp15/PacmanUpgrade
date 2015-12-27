using UnityEngine;
using System.Collections.Generic;

public class Elsa : MonoBehaviour {

	private BezierCurve jumpCurve;


	public GameObject[] jumpPoints;
	private Vector3[] airPointsPositions;
	private Vector3[] points;

	private Vector3 pointA;
	private Vector3 pointB;
	private float journeyLength;


	private Vector3 currentPosition;

	public Transform jumpTarget;

	private const int jumpSteps = 10;



	public float elsaSpeed;

	private float startTime;
	private float distCovered;
	private float fracJourney;



	int currentPoint;


	void Start () {

		startTime = Time.time;

		elsaSpeed = 1f;
		currentPosition = transform.localPosition;
		jumpCurve = GetComponent<BezierCurve>();
		airPointsPositions = new Vector3[11];

		points = new Vector3[3];

		CalculatePoints();
		List10Points();

		currentPoint = 0;

		SetPoints();



	}

	void Update () {

		float distCovered = (Time.time - startTime) * elsaSpeed;
		float fracJourney = distCovered/journeyLength;

		transform.localPosition = Vector3.Lerp(pointA, pointB, fracJourney);
		if(fracJourney >= 1f && currentPoint + 1 < points.Length)
		{
			currentPoint++;
			SetPoints(); 
		}

			
	

	}

	void Jump()
	{
		for(int i = 1; i < airPointsPositions.Length; i++)

			transform.localPosition = Vector3.Lerp(airPointsPositions[i-1], airPointsPositions[i], Time.deltaTime);
 	}
	void SetPoints()
	{
		Vector3 pointA = airPointsPositions[currentPoint];
		Vector3 pointB = airPointsPositions[currentPoint + 1];
		startTime = Time.time;
		journeyLength = Vector3.Distance(pointA, pointB);

	
	}
	void CalculatePoints()
	{
		points[0] = transform.localPosition;
		points[1] = new Vector3(transform.localPosition.x, points[2].z * 0.4f, points[2].z * 0.75f);
		points[2] = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 16.0f);

		Debug.Log(points[2].ToString());
	}
	Vector3 CalculateDerivitive(Vector3 p0, Vector3 p1, Vector3 p2, float t)
	{
		t = Mathf.Clamp01(t);
		float oneMinusT = 1f - t;
		return
			oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
	}

	void List10Points()
	{
		for(int i = 1; i <= jumpSteps; i++)
		{
			airPointsPositions[i] = CalculateDerivitive(points[0], points[1], points[2], (float)i/ (float)jumpSteps);

			Debug.Log(airPointsPositions[i].ToString());
		}
	}
}
