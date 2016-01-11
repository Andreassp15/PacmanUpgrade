using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject printerObject;
	Printer printerScript;
	public GameObject triggerPath;

	//public GameObject abilityMasterObject;
	//AbilityMaster abilityMasterScript;

	public GameObject openPathOne;
	public GameObject openPathTwo;
	public GameObject openPathThree;

	public float pathWaitTime;
	public bool startPathTimerFromStart;

	/*public GameObject InfoCoins;
	public GameObject InfoDiamonds;
	public GameObject InfoTeleports;
	public GameObject InfoGhostHurts;
	public GameObject Info*/

	void Start () {
		if(startPathTimerFromStart == true){
			StartCoroutine(OpenPath());
		}
		printerScript = printerObject.GetComponent<Printer>();



	}
	public void StartTimerForPath(){
		StartCoroutine(OpenPath());
	}

	IEnumerator OpenPath(){
		yield return new WaitForSeconds(pathWaitTime);
		openPathOne.SetActive(false);
		openPathTwo.SetActive(false);
		openPathThree.SetActive(false);
	}
	public void PrintInfo(GameObject theBox){
		if(theBox.gameObject.name == "InfoCoins"){
			printerScript.PrintTutorialPanel("Gather all the Gold Coins! Each coin gives you 1 point. When you gathered all the coins you are victorious");
		}else if(theBox.gameObject.name == "InfoDiamonds"){
			printerScript.PrintTutorialPanel("The Blue Coins are larger and more valuble, Collect them and gain some bonus points");
		}else if(theBox.gameObject.name == "InfoTeleports"){
			printerScript.PrintTutorialPanel("Enter the Teleport Gateway to teleport to the otherside");
		}else if(theBox.gameObject.name == "InfoGhostsHurt"){
			printerScript.PrintTutorialPanel("You must be careful! The rock looking ghosts will kill you if you touch them");
		}else if(theBox.gameObject.name == "InfoCourage"){
			printerScript.PrintTutorialPanel("The Green Coin is called Courage Coin. These coins will make the ghost scared of you for 10 seconds and you will hunt them instead");
		}else if(theBox.gameObject.name == "InfoGhostFlee"){
			printerScript.PrintTutorialPanel("Ghosts runs to their nests and hide for some time, and then go back to thier normal hunt mode. But because your a noob will keep them still for now");
		}else if(theBox.gameObject.name ==  "InfoUseShield"){
			printerScript.PrintTutorialPanel("Wait a second ill remove this rock for you! Now use your Shield pressing SPACE key and teleport yourself to the other side of the ghost by using SPACE again ");
		}else if(theBox.gameObject.name ==  "InfoUseMagnet"){
			printerScript.PrintTutorialPanel("Wait a second ill remove this rock for you! Now use you Magnet pressing SPACE key to gather the coins on the other side of the trees");
		}else if(theBox.gameObject.name == "InfoUseDecoy"){
			printerScript.PrintTutorialPanel("Wait a second ill remove this rock for you! Now use you Decoy on the marked spot pressing SPACE key to trick the ghost to thinking its you");
		}else if(theBox.gameObject.name ==  "InfoUseShield2"){
			printerScript.PrintTutorialPanel("Now use your shiled but be careful so you shield dont get stuck in the trees!");
		}else if(theBox.gameObject.name ==  "InfoUseMagnet2"){
			printerScript.PrintTutorialPanel("Gather the coins but be carful. If your magnet hit ghost they become faster and harder to pass");
		}else if(theBox.gameObject.name ==  "InfoUseDecoy2"){
			printerScript.PrintTutorialPanel("One more step and ghosts might detect you! Use your Decoy on the marked spot and hide on the left side");
		}else if(theBox.gameObject.name ==  "InfoAvoidArrows"){
			printerScript.PrintTutorialPanel("Watch out! There must be someone in the bushes shooting poisonus arrows at you! You can only be hit by 3 arrows before dying");
		}else if(theBox.gameObject.name ==  "InfoMeteors"){
			printerScript.PrintTutorialPanel("You ended up in a meteor shower! they kill kill you instantly if you are hit by them or the explosion that followes");
		}else if(theBox.gameObject.name ==  "InfoShieldPowerCharge"){
			printerScript.PrintTutorialPanel("The Purple Coin is called a PowerCharge.These will make you ability stronger when used. Pick it up and use it by pressing E button. And now throw your shield at the ghost");
		}else if(theBox.gameObject.name ==  "InfoDecoyPowerCharge"){
			printerScript.PrintTutorialPanel("The Purple Coin is called a PowerCharge.These will make you ability stronger when used. Pick it up and use it by pressing E button. And now place your decoy on the marked spot");
		}else if(theBox.gameObject.name ==  "InfoMagnetPowerCharge"){
			printerScript.PrintTutorialPanel("The Purple Coin is called a PowerCharge.These will make you ability stronger when used. Pick it up and use it by pressing E button. And now use you magnet and take no damage from the arrows");
		}else if(theBox.gameObject.name ==  "InfoMagnetPowerCharge2"){
			printerScript.PrintTutorialPanel("Your magnet also blocks meteors and other explosions");
		}else if(theBox.gameObject.name ==  "YouAreReady"){

		}
		theBox.gameObject.SetActive(false);
	}

		
	void Update () {
	
	}
}
