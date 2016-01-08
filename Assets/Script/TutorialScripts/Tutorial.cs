using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject printerObject;
	Printer printerScript;
	//public GameObject path;

	//public GameObject abilityMasterObject;
	//AbilityMaster abilityMasterScript;

	public GameObject openPathOne;
	public float pathWaitTime;

	/*public GameObject InfoCoins;
	public GameObject InfoDiamonds;
	public GameObject InfoTeleports;
	public GameObject InfoGhostHurts;
	public GameObject Info*/

	void Start () {
		printerScript = printerObject.GetComponent<Printer>();
		StartCoroutine(OpenPath());


	}

	IEnumerator OpenPath(){
		yield return new WaitForSeconds(pathWaitTime);
		openPathOne.SetActive(false);
	}
	public void PrintInfo(GameObject theBox){
		if(theBox.gameObject.name == "InfoCoins"){
			Debug.Log("hello");
			printerScript.PrintInfoText("Gather all the Gold Coins! Each coin gives you 1 point. When you gathered all the coins you are victorious");
			//printerScript.TutorialInfo("Gather all the Gold Coins! Each coin gives you 1 point. When you gathered all the coins you are victorious");
		}else if(theBox.gameObject.name == "InfoDiamonds"){
			Debug.Log("Diamons");printerScript.PrintInfoText("The Blue Coins are larger and more valuble, Collect them and gain some bonus points");
			//printerScript.TutorialInfo("The Blue Coins are larger and more valuble, Collect them and gain some bonus points");
		}else if(theBox.gameObject.name == "InfoTeleports"){
			//printerScript.TutorialInfo("Enter the Teleport Gateway to teleport to the otherside");
		}else if(theBox.gameObject.name == "InfoGhostsHurt"){
			
		}else if(theBox.gameObject.name == "InfoCourage"){

		}else if(theBox.gameObject.name == "InfoGhostFlee"){

		}else if(theBox.gameObject.name ==  "InfoUseShield"){

		}else if(theBox.gameObject.name ==  "InfoUseMagnet"){

		}else if(theBox.gameObject.name == "InfoUseDecoy"){

		}else if(theBox.gameObject.name ==  "InfoUseShield2"){

		}else if(theBox.gameObject.name ==  "InfoUseMagnet2"){

		}else if(theBox.gameObject.name ==  "InfoUseDecoy2"){

		}else if(theBox.gameObject.name ==  "InfoAvoidArrows"){

		}else if(theBox.gameObject.name ==  "InfoArrowsDamage"){

		}else if(theBox.gameObject.name ==  "InfoMeteors"){

		}else if(theBox.gameObject.name ==  "InfoMeteorsSurvive"){

		}else if(theBox.gameObject.name ==  "InfoShieldPowerCharge"){

		}else if(theBox.gameObject.name ==  "InfoDecoyPowerCharge"){

		}else if(theBox.gameObject.name ==  "InfoMagnetPowerCharge"){

		}else if(theBox.gameObject.name ==  "InfoMagnetPowerCharge2"){

		}else if(theBox.gameObject.name ==  "YouAreReady"){

		}
	}

		
	void Update () {
	
	}
}
