using UnityEngine;
using System.Collections;

public class BossEvent : MonoBehaviour {



	//--------Bomb and Force---------//
	public Rigidbody bombPrefab;
	public float thrust;
	//--------BombSpawnPoints--------//

	public Transform spawnOne;
	public Transform spawnTwo;
	public Transform spawnThree;
	public Transform spawnFour;
	public Transform spawnFive;
	public Transform spawnSix;
	public Transform spawnSeven;
	public Transform spawnEight;

	public GameObject bombZoneOne;
	public GameObject bombZoneTwo;

	bool one = false;
	bool two = false;


	private float delay = 1.5f;

	int direction;



	public void FixedUpdate()
	{
		//		direction = Random.Range (1,9); // Temporär
		GameObject existBomb = GameObject.FindWithTag ("Bomb");


		if (existBomb == null && bombZoneOne == true && one == true) {    
			Rigidbody bomb;
			bomb = Instantiate (bombPrefab, spawnOne.position, spawnOne.rotation) as Rigidbody;
			bomb.AddForce (250f, 1f, -1f * thrust);
			Debug.Log ("Funkar 1");
			Invoke ("destroyBomb", delay);
			one = false;
		} else if (existBomb == null && bombZoneTwo == true && two == true) {    
			Rigidbody bomb;
			bomb = Instantiate (bombPrefab, spawnTwo.position, spawnTwo.rotation) as Rigidbody;
			bomb.AddForce (transform.forward * -thrust);
			Debug.Log ("Funkar 2");
			Invoke ("destroyBomb", delay);
		}
	}
		public void zoonOneTrue(){
		one = false;
		two = true;
		}

//		else if (existBomb == null && direction== 3) 
//		{    
//			Rigidbody bomb;
//			bomb = Instantiate (bombPrefab, spawnThree.position, spawnOne.rotation) as Rigidbody;
//			bomb.AddForce (transform.forward * thrust);
//			Debug.Log ("Funkar 3");
//			Invoke ("destroyBomb", delay);
//		}
//		else if (existBomb == null && direction== 4) 
//		{    
//			Rigidbody bomb;
//			bomb = Instantiate (bombPrefab, spawnFour.position, spawnOne.rotation) as Rigidbody;
//			bomb.AddForce (-200f, 1f, 1f * thrust);
//			Debug.Log ("Funkar 4");
//			Invoke ("destroyBomb", delay);
//		}
//		else if (existBomb == null && direction== 5) 
//		{    
//			Rigidbody bomb;
//			bomb = Instantiate (bombPrefab, spawnFive.position, spawnOne.rotation) as Rigidbody;
//			bomb.AddForce (transform.right * -thrust);
//			Debug.Log ("Funkar 5");
//			Invoke ("destroyBomb", delay);
//		}
//		else if (existBomb == null && direction== 6) 
//		{    
//			Rigidbody bomb;
//			bomb = Instantiate (bombPrefab, spawnSix.position, spawnOne.rotation) as Rigidbody;
//			bomb.AddForce (-200f, 1f, -1f * thrust);
//			Debug.Log ("Funkar 6");
//			Invoke ("destroyBomb", delay);
//		}
//		else if (existBomb == null && direction== 7) 
//		{    
//			Rigidbody bomb;
//			bomb = Instantiate (bombPrefab, spawnSeven.position, spawnOne.rotation) as Rigidbody;
//			bomb.AddForce (transform.forward * -thrust);
//			Debug.Log ("Funkar 7");
//			Invoke ("destroyBomb", delay);
//		}
//		else if (existBomb == null && direction== 8) 
//		{    
//			Rigidbody bomb;
//			bomb = Instantiate (bombPrefab, spawnEight.position, spawnOne.rotation) as Rigidbody;
//			bomb.AddForce (200f, 1f, -1f * thrust);
//			Debug.Log ("Funkar 8");
//			Invoke ("destroyBomb", delay);
//		}
//	}

	public void destroyBomb()
	{
		Destroy(GameObject.FindWithTag("Bomb"));

	}
} 