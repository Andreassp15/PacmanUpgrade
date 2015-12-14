using UnityEngine;
using System.Collections;

public class MeteorMaster : MonoBehaviour {

	public GameObject[] meteorArray;


	void Start () {
		InvokeRepeating("MeteorSpawnPosition", 0, 2);
	
	}
	void MeteorSpawnPosition(){
		int randomMeteor = Random.Range(0, meteorArray.Length);
		if(meteorArray[randomMeteor].gameObject.activeSelf == false){
			float randomPositionX = Random.Range(-10f, 10f);
			float randomPositionZ = Random.Range(-10f, 10f);
			meteorArray[randomMeteor].gameObject.transform.position = new Vector3(randomPositionX, 25f, randomPositionZ);
			meteorArray[randomMeteor].gameObject.GetComponent<SphereCollider>().radius = 0.5f;
			meteorArray[randomMeteor].SetActive(true);
		}else{
			MeteorSpawnPosition();
		}


	}

	void Update () {
	
	}
}
