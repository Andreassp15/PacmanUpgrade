using UnityEngine;
using System.Collections;

public class Fire_Checkpoints : MonoBehaviour {


	private bool[] points = new bool[4] {false, false, false, false};

	public void AddPoint(int o)
	{
		points[o] = true;

		if(AllActive() == true)
		{

			transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();

			GetComponentInParent<Mama_Checkpoint>().AddCheckpoint();

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
}
