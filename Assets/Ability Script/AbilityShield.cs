using UnityEngine;
using System.Collections;

public class AbilityShield : MonoBehaviour {

	public GameObject ShieldRotate;
	public GameObject ShieldInWall;
	public GameObject useShieldObject;
	UseShield useShieldScript;

	public GameObject PacmanMoveObject;
	pacmanMove pacmanMoveScript;

	bool willReturn = true;
	float dX;
	float dZ;
	float xyzInWall = 0.5f;

	Vector3 direction;
	float moveSpeed = 0.1f;

	void Start () {
		useShieldScript = useShieldObject.GetComponent<UseShield>();

	}
	public void StartDirection(){
		ShieldRotate.gameObject.SetActive(true);
		ShieldInWall.gameObject.SetActive(false);
		pacmanMoveScript = PacmanMoveObject.GetComponent<pacmanMove>();
		willReturn = true;
		dX = pacmanMoveScript.ReturnDirectionX();
		dZ = pacmanMoveScript.ReturnDirectionZ();
		if(dX == 0 && dZ == 1){
			direction = new Vector3(0, 0, 1.2f);
			Debug.Log("hello");
		}else if(dX == 0 && dZ == -1){
			direction = new Vector3(0, 0, -1.2f);
			Debug.Log("back");
		}else if(dX == 1 && dZ == 0){
			direction = new Vector3(1.2f, 0, 0);
		}else if(dX == -1 && dZ == 0){
			direction = new Vector3(-1.2f, 0, 0);
		}

		StartCoroutine(ReturnToPacman(direction));
	}
	IEnumerator ReturnToPacman(Vector3 dir){

		yield return new WaitForSeconds(1.5f);
		if(willReturn == true){
			//onReturn = true;
			direction = -dir;
		}
	}
	void FixedUpdate () {


		transform.Translate(direction * moveSpeed);
	}
	void OnTriggerEnter(Collider Trigger){
		if(Trigger.gameObject.tag == "Wall"){
			useShieldScript.ShieldInWall();
			ShieldRotate.gameObject.SetActive(false);
			PushShieldInWall();
			ShieldInWall.gameObject.SetActive(true);
			direction = new Vector3(0, 0, 0);
			willReturn = false;
		}else if(Trigger.gameObject.tag == "Pacman"){
			useShieldScript.OwnShield();
			ShieldInWall.gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}
	void PushShieldInWall(){
			if(direction == new Vector3(0, 0, 1.2f)){
				ShieldInWall.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + xyzInWall);
			}else if(direction == new Vector3(0, 0, -1.2f)){
				ShieldInWall.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - xyzInWall);
			}else if(direction == new Vector3(1.2f, 0, 0)){
				ShieldInWall.gameObject.transform.position = new Vector3(transform.position.x + xyzInWall, transform.position.y, transform.position.z);
			}else if(direction == new Vector3(-1.2f, 0, 0)){
				ShieldInWall.gameObject.transform.position = new Vector3(transform.position.x - xyzInWall, transform.position.y, transform.position.z + xyzInWall);
			}	
	}


}
