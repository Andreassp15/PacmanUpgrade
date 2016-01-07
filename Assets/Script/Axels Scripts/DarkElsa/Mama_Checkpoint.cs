using UnityEngine;
using System.Collections;

public class Mama_Checkpoint : MonoBehaviour {

	private int checkpointTurnedOn  = 0;

	private bool elsaDead = false;

	public void AddCheckpoint()
	{
		checkpointTurnedOn++;

		if(checkpointTurnedOn == 8)
		{
			elsaDead = true;
			Debug.Log("Elsa Died!");
		}
	}
	public void SubtractCheckpoint()
	{
		checkpointTurnedOn--;
	}
	public bool isElsaDead()
	{
		return elsaDead;
	}
}
