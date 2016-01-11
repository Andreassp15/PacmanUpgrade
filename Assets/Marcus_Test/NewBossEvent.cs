using UnityEngine;
using System.Collections.Generic;

//*******//Main Boss Script//*******// 

public class NewBossEvent : MonoBehaviour {


	//--------Bomb------//
	//Here we create a few variables, these are for the bomb itself aswell as the bombZones that the player can trigger to get the boss to throw the bomb.
	//also we have variables that decide when the bomb will go off and when the death zone will be activated.
	public GameObject bomb;// The bomb itself:
	BombForceStart ballSpawn; // The script that activates the bomb so that forces can be applied to it.
	public Rigidbody bombStop;
	public float bombGoBoom;
	public float bombZoneOn;
	public GameObject killZoneOne;
	public GameObject killZoneTwo;
	public GameObject killZoneThree;
	public GameObject killZoneFour;
	public GameObject killZoneFive;
	public GameObject killZoneSix;
	public GameObject killZoneSeven;
	public GameObject killZoneEight;

	//----------------Animation-------------//
	public GameObject trollKing;
	TrollKing playAnimation;


	//----------------Sounds---------//
	public AudioPlayer sounds;
	AudioPlayer soundActivate;



	//------------Bombzones och SpawnsZones---------------//
	public GameObject[] bZones;//Here goes all the zones that pacman can trigger for the boss to throw the bomb.
	public Transform ballReturn;// This is for the return point and start point for the bomb, so that it always is thrown from the same point in ralation to the boss and pacman.



	// Here all the zones are set to off so the boss wont throw bombs from the start, also this turns of the bomb so that it wont just float arround randomly on the map.
	public void Start()
	{
		soundActivate = sounds.GetComponent<AudioPlayer> ();
		soundActivate.BackgroundMusicMethod ();

		playAnimation = trollKing.GetComponent<TrollKing> ();

		ballSpawn = bomb.GetComponent<BombForceStart> ();
		bomb.SetActive (false);
		killZoneOne.SetActive (false);
		killZoneTwo.SetActive (false);
		killZoneThree.SetActive (false);
		killZoneFour.SetActive (false);
		killZoneFive.SetActive (false);
		killZoneSix.SetActive (false);
		killZoneSeven.SetActive (false);
		killZoneEight.SetActive (false);
	}
	//This is the method that will make the boss turn and look at the zone that pacman triggerd, and here we make the bomb active so that we can throw it towards the player.
	//also makes the bombZones active so that when the bomb goes off they will change and become deadly for the player to enter.
	public void ZoneActivated(GameObject theObject)
	{
		GameObject existBomb = GameObject.FindWithTag ("Bomb");


		for(int i = 1; i <= bZones.Length;i++)
		{
			if (existBomb == null && bZones[0] == theObject) 
			{
				transform.localEulerAngles = new Vector3 (0f, 135f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionOne", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[1] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionTwo", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[2] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, -135f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionThree", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[3] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionFour", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[4] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, -45f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionFive", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[5] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionSix", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[6] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 45f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionSeven", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
			else if(existBomb == null && bZones[7] == theObject)
			{
				transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				Invoke ("BombActivate", 0.8f);
				Invoke ("BombReturn", bombGoBoom);
				Invoke ("ExplosionEight", 5f);
				playAnimation.PlayThrowAnimaton ();
				soundActivate.TrollTalk ();
			}
	
		}
	}

	//This makes activates the bomb and makes its rotation and position is like the boss. 
	public void BombActivate()
	{
		bomb.transform.position = ballReturn.transform.position;
		bomb.transform.rotation = ballReturn.transform.rotation;
		ballSpawn.PowerOn ();
		bomb.SetActive (true);
	}

	//This will return the bomb when it has gone off.
	public void BombReturn ()
	{
		bomb.transform.position = ballReturn.transform.position;
		bomb.SetActive (false);
		bombStop.GetComponent<Rigidbody> ();
		bombStop.velocity = bombStop.velocity = new Vector3 (0f, 0f, 0f);
		Debug.Log ("Stop");
	}
		//These activate the death zones so that the player will be able to die. 
	public void ExplosionOne()
	{
		killZoneOne.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	public void ExplosionTwo()
	{
		killZoneTwo.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	public void ExplosionThree()
	{
		killZoneThree.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	public void ExplosionFour()
	{
		killZoneFour.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	public void ExplosionFive()
	{
		killZoneFive.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	public void ExplosionSix()
	{
		killZoneSix.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	public void ExplosionSeven()
	{
		killZoneSeven.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
	}

	public void ExplosionEight()
	{
		killZoneEight.SetActive (true);
		Invoke ("ExplosionOff", bombZoneOn);
		soundActivate.TrollBombExplodeMethod ();
	}

	//This turns these zones off so that the player can renter the zones so you can get the coins and powerups.
	public void ExplosionOff()
	{
		killZoneOne.SetActive (false);
		killZoneTwo.SetActive (false);
		killZoneThree.SetActive (false);
		killZoneFour.SetActive (false);
		killZoneFive.SetActive (false);
		killZoneSix.SetActive (false);
		killZoneSeven.SetActive (false);
		killZoneEight.SetActive (false);
	}



}