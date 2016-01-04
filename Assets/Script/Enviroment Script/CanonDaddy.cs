using UnityEngine;
using System.Collections;

public class CanonDaddy : MonoBehaviour {

	public GameObject[] canonBallArray;
	public GameObject[] explosionArray;
	public GameObject visualOrbObject;
	public GameObject visualSparksObject;

	float riseSpeed = 1.2f;
	float enlargeSpeed = 1.5f;
	float power = 7f;
	int canonBallsAmount = 0;
	Vector3 randomDirection;

	bool timeToFire = false;
	bool finnishedFire = false;
	bool enlarge = false;
	bool shrink = false;

	bool alreadyShooting = false;

	float dX;
	float dY;
	float dZ;

	void Start () {			
	}
	public void FireCanonBalls(){
		if(alreadyShooting == false){
			StartCoroutine(BeforeFireCharging());
		}
	}
	IEnumerator BeforeFireCharging(){
		alreadyShooting = true;
		timeToFire = true;
		yield return new WaitForSeconds(2f);
		timeToFire = false;
		yield return new WaitForSeconds(1f);
		enlarge = true;
		visualSparksObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		enlarge = false;
		InvokeRepeating("FireCanon",0 ,0.5f);
		yield return new WaitForSeconds(6f);
		visualSparksObject.SetActive(false);
		shrink = true;
		yield return new WaitForSeconds(3f);
		shrink = false;
		finnishedFire = true;
		yield return new WaitForSeconds(2f);
		finnishedFire = false;
		visualOrbObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		alreadyShooting = false;
	}

	void FireCanon(){
		
		if(canonBallsAmount < canonBallArray.Length){
			RandomFloats();
			randomDirection = new Vector3(dX, dY, dZ);
			canonBallArray[canonBallsAmount].transform.position = transform.position;
			canonBallArray[canonBallsAmount].SetActive(true);
			canonBallArray[canonBallsAmount].gameObject.GetComponent<Rigidbody>().AddForce(randomDirection * power, ForceMode.Impulse);
			canonBallsAmount = canonBallsAmount + 1;
		}else{
			CancelInvoke("FireCanon");
			canonBallsAmount = 0;
		}
	}
	public void ButtonPressed(){
		FireCanonBalls();
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			FireCanonBalls();
		}
	}
	void RandomFloats(){
		dX = Random.Range(-1.0f, 1.0f);
		dY = Random.Range(0.8f, 2.0f);
		dZ = Random.Range(-1.0f, 1.0f);
	}
	public void CanonBallHitSomething(GameObject theCanonBall){
		for(int i = 0; i < canonBallArray.Length; i++){
			if(canonBallArray[i] == theCanonBall){
				for(int j = 0; j < explosionArray.Length; j++){
					if(i == j){
						Vector3 ballPosition = canonBallArray[i].gameObject.transform.position;
						explosionArray[j].gameObject.transform.position = new Vector3(ballPosition.x, ballPosition.y +1.5f, ballPosition.z);

						explosionArray[j].SetActive(true);
					}
				}
			}
		}
	}
	public void CancelExplosive(GameObject theCanonBall){
		for(int i = 0; i < canonBallArray.Length; i++){
			if(canonBallArray[i] == theCanonBall){
				for(int j = 0; j < explosionArray.Length; j++){
					if(i == j){
						explosionArray[j].SetActive(false);
					}
				}
			}
		}

	}
	void FixedUpdate(){
		if(timeToFire == true){
			gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +1f, gameObject.transform.position.z), riseSpeed * Time.deltaTime);
		}else if(enlarge == true){
			visualOrbObject.gameObject.GetComponent<Transform>().localScale = Vector3.Lerp(visualOrbObject.transform.localScale, new Vector3(2, 2, 2), enlargeSpeed * Time.deltaTime);
		}
		else if(finnishedFire == true){
			gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -1f, gameObject.transform.position.z), riseSpeed * Time.deltaTime);
		}else if(shrink == true){
			visualOrbObject.gameObject.GetComponent<Transform>().localScale = Vector3.Lerp(visualOrbObject.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), enlargeSpeed * Time.deltaTime);
		}
	}



}
