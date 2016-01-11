using UnityEngine;
using System.Collections.Generic;

public class SpawnRotation : MonoBehaviour {

	public Transform one;
	public Transform two;
	public Transform three;
	public Transform four;
	public Transform five;
	public Transform six;
	public Transform seven;
	public Transform eight;

	public void ZoneOne()
	{
		transform.LookAt (one);
	}

	public void ZoneTwo()
	{
		transform.LookAt (two);
	}

	public void ZoneThree()
	{
		transform.LookAt (three);
	}

	public void ZoneFour()
	{
		transform.LookAt (four);
	}

	public void ZoneFive()
	{
		transform.LookAt (five);
	}

	public void ZoneSix()
	{
		transform.LookAt (six);
	}

	public void ZoneSeven()
	{
		transform.LookAt (seven);
	}

	public void ZoneEight()
	{
		transform.LookAt (eight);
	}

}