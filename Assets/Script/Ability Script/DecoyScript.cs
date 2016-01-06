using UnityEngine;
using System.Collections;

public class DecoyScript : MonoBehaviour {

	public GameObject abilityMasterObject;
	public GameObject pointGhostHuntingObject;
	public GameObject explosion;
	public GameObject audioPlayerObject;
	public GameObject useAbilityDecoyObject;

	UseAbilityDecoy useAbilityDecoyScript;
	AudioPlayer audioPlayerScript;
	AbilityMaster abilityMasterScript;
	PointGhostsHunting pointGhostHuntingScript;

	bool expand = false;
	float enlargeSpeed = 3f;

	void Start () {
		useAbilityDecoyScript = useAbilityDecoyObject.GetComponent<UseAbilityDecoy>();
		abilityMasterScript = abilityMasterObject.GetComponent<AbilityMaster>();
		pointGhostHuntingScript = pointGhostHuntingObject.GetComponent<PointGhostsHunting>();
		audioPlayerScript = audioPlayerObject.GetComponent<AudioPlayer>();
	}
	void OnTriggerEnter(Collider trigger){
		
		if(trigger.gameObject.tag == "GhostHunt" || trigger.gameObject.tag == "GhostFlee"){
			if(abilityMasterScript.ReturnPoweredAbilityReady() == true){
				useAbilityDecoyScript.SetAlreadyActiveTrue();
				expand = true;
				audioPlayerScript.DecoyEnlargeMethod();
				StartCoroutine(ExplodeDecoy());
				
				
			}else{
				Debug.Log("0");
				useAbilityDecoyScript.SetAlreadyActiveTrue();
				useAbilityDecoyScript.decoyGone();
				audioPlayerScript.DecoyFoundMethod();
				pointGhostHuntingScript.PacmanPositionMethod();
				gameObject.SetActive(false);
			}
		}
	}
	IEnumerator ExplodeDecoy(){
		yield return new WaitForSeconds(1f);
		explosion.SetActive(true);
		audioPlayerScript.DecoyExplodeMethod();
		gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
		pointGhostHuntingScript.PacmanPositionMethod();
		abilityMasterScript.PoweredAbilityEnd();
		expand = false;
		yield return new WaitForSeconds(0.1f);
		useAbilityDecoyScript.decoyGone();
		useAbilityDecoyScript.SetAlreadyActiveFalse();
		explosion.SetActive(false);
		gameObject.SetActive(false);
	}
	

	void FixedUpdate () {
		if(expand == true){
			gameObject.GetComponent<Transform>().localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(8, 8, 8), enlargeSpeed  * Time.deltaTime);
		}
	}
}
