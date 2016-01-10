using UnityEngine;
using System.Collections;

public class IcePike : MonoBehaviour {
	
	float lifetime = 0f;

	public ParticleSystem poof;
	public ParticleSystem warning;


	void Update()
	{
		lifetime = lifetime + Time.deltaTime;

		if(lifetime > 2.0f)
		{
			poof.Emit(50);

			gameObject.SetActive(false);

			lifetime = 0.0f;
		}
	}	

}
