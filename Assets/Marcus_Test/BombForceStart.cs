using UnityEngine;
using System.Collections.Generic;

public class BombForceStart : MonoBehaviour {

	public float power;
	public Rigidbody bomb;

	public void PowerOn()
	{
		bomb.AddForce (transform.forward * power, ForceMode.Impulse);
		bomb.AddForce (transform.up * 1f, ForceMode.Impulse);
		Debug.Log ("Pang");
	}
		
}
