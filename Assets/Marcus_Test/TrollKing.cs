using UnityEngine;
using System.Collections.Generic;

public class TrollKing : MonoBehaviour {


	void Start () 
	{
		gameObject.GetComponent<Animator> ().Play ("Idle");
	}

	public void PlayThrowAnimaton()
	{
		gameObject.GetComponent<Animator> ().Play ("Throw");
		Invoke ("PlayIdleAnimation", 2.35f);
	}

	public void PlayIdleAnimation ()
	{
		gameObject.GetComponent<Animator> ().Play ("Idle");
	}
}
