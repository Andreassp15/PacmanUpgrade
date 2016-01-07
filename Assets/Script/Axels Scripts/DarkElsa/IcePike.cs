using UnityEngine;
using System.Collections;

public class IcePike : MonoBehaviour {
	
	float lifetime = 0f;

	public ParticleSystem poof;

	void Update()
	{
		lifetime = lifetime + Time.deltaTime;

		if(lifetime > 2.0f)
		{
			gameObject.SetActive(false);


			lifetime = 0.0f;
		}
	}	

}
