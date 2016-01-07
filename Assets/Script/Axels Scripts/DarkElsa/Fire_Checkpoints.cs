using UnityEngine;
using System.Collections;

public class Fire_Checkpoints : MonoBehaviour {

	private int pointsTurnedOn = 0;


	public void AddPoint()
	{
		pointsTurnedOn++;

		if(pointsTurnedOn == 4)
		{

			transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();

			GetComponentInParent<Mama_Checkpoint>().AddCheckpoint();

			for(int i = 0; i <= 3; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}

	public void SubtractPoint()
	{
		pointsTurnedOn--;
	}
}
