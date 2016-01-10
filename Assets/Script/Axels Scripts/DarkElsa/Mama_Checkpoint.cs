using UnityEngine;
using System.Collections.Generic;

public class Mama_Checkpoint : MonoBehaviour {

	private int checkpointTurnedOn  = 0;
	private Dictionary<GameObject, GameObject> pairedCoins;
	private List<GameObject> fireCheckpoints;
	private List<GameObject> coins;


	void Start()
	{
		coins = new List<GameObject>();
		fireCheckpoints = new List<GameObject>();

		for(int i = 0; i < 8; i++)
		{
			coins.Add(transform.GetChild(8).GetChild(i).gameObject);
			fireCheckpoints.Add(transform.GetChild(i).gameObject);
		}
	}

	private bool elsaDead = false;

	public void AddCheckpoint()
	{
		checkpointTurnedOn++;

		if(checkpointTurnedOn == 8)
		{
			elsaDead = true;
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
	public void ActivateCoin(GameObject o)
	{
		for(int i = 0; i < fireCheckpoints.Count; i++)
		{
			if(o.name == fireCheckpoints[i].name)
			{
				coins[i].SetActive(true);

				break;
			}
		}
	}
}
