using UnityEngine;
using System.Collections.Generic;

public class Mama_Checkpoint : MonoBehaviour {

	private int checkpointTurnedOn  = 0;
	private Dictionary<GameObject, GameObject> pairedCoins;
	private List<GameObject> fireCheckpoints;
	private List <Transform> centerPoints;
	private List<GameObject> coins;


	void Start()
	{
		coins = new List<GameObject>();
		fireCheckpoints = new List<GameObject>();
		centerPoints = new List<Transform>();



		for(int i = 0; i < 8; i++)
		{
			coins.Add(transform.GetChild(8).GetChild(i).gameObject);
			fireCheckpoints.Add(transform.GetChild(i).gameObject);
			centerPoints.Add(transform.GetChild(9).GetChild(i));

		}
	}

	private bool elsaDead = false;

	public void AddCheckpoint()
	{
		coins[checkpointTurnedOn].transform.position = centerPoints[checkpointTurnedOn].position;

		checkpointTurnedOn++;
		transform.parent.GetChild(0).GetComponent<ElsaController>().AddFireCheckpoint();

		if(checkpointTurnedOn == 4)
		{
			transform.parent.GetChild(0).GetComponent<ElsaController>().ChangeMusic(true);
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
