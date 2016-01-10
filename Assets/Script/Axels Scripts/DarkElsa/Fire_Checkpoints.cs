using UnityEngine;
using System.Collections.Generic;


public class Fire_Checkpoints : MonoBehaviour {


	private bool[] points = new bool[4] {false, false, false, false};
	private GameObject[] kids;
	private GameObject purpMagic;
	private ParticleSystem.MinMaxCurve emissionRate;
	private GameObject[] iceSpikes;

	void Start()
	{
		kids = new GameObject[4];
		iceSpikes = new GameObject[4];

		purpMagic = transform.GetChild(5).gameObject;
		emissionRate = purpMagic.GetComponent<ParticleSystem>().emission.rate;

		for(int i = 0; i < 4; i++)
		{
			kids[i] = transform.GetChild(i).gameObject;
			iceSpikes[i] = transform.parent.parent.GetChild(i + 2).gameObject;
		}
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
	public void MultiSpikeAttack()
	{
		for(int i = 0; i < 4; i++)
		{
				iceSpikes[i].transform.GetChild(2).gameObject.SetActive(true);
				iceSpikes[i].transform.position = kids[i].transform.position;
		}
	
	}
}
