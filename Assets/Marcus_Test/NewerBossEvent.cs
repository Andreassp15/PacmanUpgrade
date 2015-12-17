using UnityEngine;
using System.Collections.Generic;

public class NewerBossEvent : MonoBehaviour {

	//--------Bomb and Force---------//
	public Rigidbody bombPrefab;
	public float power;
	public float delay = 1.2f;
	Rigidbody bomb;

	public void ZoneActivated (Vector3 zonePosition)
	{
//		Vector3 spawnPosition = Vector3.ClampMagnitude (zonePosition, -10);
		bomb = Instantiate (bombPrefab,zonePosition,Quaternion.identity) as Rigidbody;
	}

	public void FixedUpdate()
	{
		bomb.AddForce (1f, 7.5f, 1f * power);
	}

}
