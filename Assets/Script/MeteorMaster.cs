using UnityEngine;
using System.Collections;

public class MeteorMaster : MonoBehaviour {

	public GameObject[] meteorArray;
	public float randomX;
	public float randomZ;
	public int fireRate;
	public int waitTime;

	void Start () {
		InvokeRepeating("MeteorSpawnPosition", waitTime, fireRate);
	
	}
	void MeteorSpawnPosition(){
		int randomMeteor = Random.Range(0, meteorArray.Length);
		if(meteorArray[randomMeteor].gameObject.activeSelf == false){
			float randomPositionX = Random.Range(-randomX, randomX);
			float randomPositionZ = Random.Range(-randomZ, randomZ);
			meteorArray[randomMeteor].gameObject.transform.position = new Vector3(randomPositionX, 25f, randomPositionZ);
			meteorArray[randomMeteor].gameObject.GetComponent<SphereCollider>().radius = 0.5f;
			meteorArray[randomMeteor].gameObject.GetComponent<Renderer>().enabled = true;
			meteorArray[randomMeteor].gameObject.GetComponent<Meteor>().ActivateSpeed();
			meteorArray[randomMeteor].SetActive(true);
		}else{
			MeteorSpawnPosition();
		}


	}

	void Update () {
	
	}
}
