using UnityEngine;
using System.Collections.Generic;


public class Fire_Checkpoints : MonoBehaviour {


	private bool[] points = new bool[4] {false, false, false, false};
	private GameObject purpMagic;
	private ParticleSystem.MinMaxCurve emissionRate;

	void Start()
	{
		purpMagic = transform.GetChild(5).gameObject;
		emissionRate = purpMagic.GetComponent<ParticleSystem>().emission.rate;
	}


	public void AddPoint(int o)
	{

		PurpleMagic(o);
		points[o] = true;


		if(AllActive() == true)
		{

			transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();

			GetComponentInParent<Mama_Checkpoint>().AddCheckpoint();

			transform.parent.GetComponent<Mama_Checkpoint>().ActivateCoin(gameObject);

			for(int i = 0; i <= 3; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
	private bool AllActive()
	{

		bool status = new bool();


		for(int i = 0; i < points.Length; i++)
		{
			status = points[i];

			if(status == false)
			{
				break;
			}
			else
			{
				status = true;
			}

		}

		return status;

	}
		
	private void PurpleMagic(int o)
	{
		
			if(points[o] == false)
			{
			purpMagic.GetComponent<ParticleSystem>().Emit(100);
			}
	}
}
