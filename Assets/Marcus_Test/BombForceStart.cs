using UnityEngine;
using System.Collections.Generic;

public class BombForceStart : MonoBehaviour {

	//Creating values that can be changed to make the boss "throw" the bomb further.
	public float power;
	public Rigidbody bomb;

	//applies the force to the bomb when it is called on, also this makes the bomb fly in an arch.
	public void PowerOn()
	{
		bomb.AddForce (transform.forward * power, ForceMode.Impulse);
		bomb.AddForce (transform.up * 1f, ForceMode.Impulse);
		Debug.Log ("Pang");
	}
		
}
