using UnityEngine;
using System.Collections;
//*******************************************************************************************''
//scriptet rör pacman genom att kontrollera vilka gånga som är fria via boxcolliders
//************************************************************************************************
public class pacmanMove : MonoBehaviour {

	public GameObject frontBox;
	public GameObject rightBox;
	public GameObject backBox;
	public GameObject leftBox;

	public GameObject spawnPoint;
	public GameObject visualPacman;

	boxMovement boxMovementScriptFront;
	boxMovement boxMovementScriptRight;
	boxMovement boxMovementScriptBack;
	boxMovement boxMovementScriptLeft;

	bool frontBool;
	bool rightBool;
	bool backBool;
	bool leftBool;

	int savedTurn = 0; 
	
	float moveSpeed;
	float dontMove = 0f;
	float normalSpeed = 0.1f;
	float dX;
	float dZ;
	Vector3 direction;

	void Start () {

		dZ = 1f;
		moveSpeed = normalSpeed;
		boxMovementScriptFront = frontBox.gameObject.GetComponent<boxMovement>();
		boxMovementScriptRight = rightBox.gameObject.GetComponent<boxMovement>();
		boxMovementScriptBack = backBox.gameObject.GetComponent<boxMovement>();
		boxMovementScriptLeft = leftBox.gameObject.GetComponent<boxMovement>();
	}
	void FixedUpdate(){

		GettingBoxBools();
		BoxHitWall();
		savedTurnMethod();
		
		direction = new Vector3(dX, 0, dZ);         // vilken riktning pacman ska åka i
		transform.Translate(direction * moveSpeed);	// flyttar pacman
	}
//-------------Player KeyButtons-------------------------
	void Update () {
		//Spelaren väljer riktning, scriptet kontrollerar om boolen för den valad riktningen är true,
		//get pacman en ny färdriktning, ger pacman fart, roterar det visuella pacamn objektet
		//annars sparas vilken riktning du valt.
		if(Input.GetKeyDown(KeyCode.W)){
			if(frontBool == true){
				dX = 0; dZ = 1;
				NormalSpeedMethod();
				savedTurn = 0;
				VisualPacmanMethod(dX, dZ);
			}else{
				savedTurn = 1;
			}	
		}
		if(Input.GetKeyDown(KeyCode.S)){
			if(backBool == true){
				dX = 0; dZ = -1;
				NormalSpeedMethod();
				savedTurn = 0;
				VisualPacmanMethod(dX, dZ);
			}else{ 
				savedTurn = 2;
			}

		}
		if(Input.GetKeyDown(KeyCode.A)){
			if(leftBool == true){
				dX = -1; dZ = 0;
				NormalSpeedMethod();
				savedTurn = 0;
				VisualPacmanMethod(dX, dZ);
			}else{
				savedTurn = 3;
			}
		}

		if(Input.GetKeyDown(KeyCode.D)){
			if(rightBool == true){
				dX = 1; dZ = 0;
				NormalSpeedMethod();
				savedTurn = 0;
				VisualPacmanMethod(dX, dZ);
			}else{
				savedTurn = 4;
			}
		}
	
	}
//----------------Give Pacman Speed-----------------
	void NormalSpeedMethod(){
		moveSpeed = normalSpeed;
	}
//----------------Remove pacman Speed---------------------
	public void DontMoveMethod(){
		moveSpeed = dontMove;
	}
//----------------Checks if Box HIt Wall--------------------- 
	void BoxHitWall(){
		//kontrollerar pacmans riktning och om riktningen är false.
		if(dX == 0 && dZ == 1 && frontBool == false){
			DontMoveMethod();
			if(savedTurn == 2 && backBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 3 && leftBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 4 && rightBool == true){
				NormalSpeedMethod();
			}
		}else if(dX == 0 && dZ == -1 && backBool == false){
			DontMoveMethod();
			if(savedTurn == 1 && frontBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 3 && leftBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 4 && rightBool == true){
				NormalSpeedMethod();
			}
		}else if(dX == -1 && dZ == 0 && leftBool == false){
			DontMoveMethod();
			if(savedTurn == 2 && backBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 1 && frontBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 4 && rightBool == true){
				NormalSpeedMethod();
			}
		}else if(dX == 1 && dZ == 0 && rightBool == false){
			DontMoveMethod();
			if(savedTurn == 2 && backBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 3 && leftBool == true){
				NormalSpeedMethod();
			}else if(savedTurn == 1 && frontBool == true){
				NormalSpeedMethod();
			}
		}

	}
//------------Bools from BoxColliders (BoxMOvement Script)------
	void GettingBoxBools(){
		frontBool = boxMovementScriptFront.ReturnBoxOK();
		rightBool = boxMovementScriptRight.ReturnBoxOK();
		backBool = boxMovementScriptBack.ReturnBoxOK();
		leftBool = boxMovementScriptLeft.ReturnBoxOK();

	}
//---------------Saved Turn---------------------------------
	void savedTurnMethod(){
	//kontrollerar vilen riktning som sparats med aldrig använts. så fort den riktningen blir true och
	//spelern int valt en ny riktning byter pacman till det spared värdets riktning.
		if(savedTurn == 1 && frontBool == true){
			dX = 0; dZ = 1;
			VisualPacmanMethod(dX, dZ);
			savedTurn = 0;
		}else if(savedTurn == 2 && backBool == true){
			dX = 0; dZ = -1;
			VisualPacmanMethod(dX, dZ);
			savedTurn = 0;
		}else if(savedTurn == 3 && leftBool == true){
			dX = -1; dZ = 0;
			VisualPacmanMethod(dX, dZ);
			savedTurn = 0;
		}else if(savedTurn == 4 && rightBool == true){
			dX = 1; dZ = 0;
			VisualPacmanMethod(dX, dZ);
			savedTurn = 0;
		}
	}
//-------------------Teleport To SpawnPoint---------------
	public void TeleportToSpawnPoint(){
	//körs från Connector då pacman ska respawnas
		transform.position = spawnPoint.gameObject.transform.position;
		DontMoveMethod();
	//sätter alla boxColliders till true. 
		boxMovementScriptFront.SetWallZero();
		boxMovementScriptBack.SetWallZero();
		boxMovementScriptLeft.SetWallZero();
		boxMovementScriptRight.SetWallZero();
	}
//--------------------Visual Pacman-------------------------
	void VisualPacmanMethod(float x, float z){
		//roterar pacmans visuella gamobject i spelerens valda riktning
		if(x == 0 && z == 1){
			visualPacman.transform.localEulerAngles = new Vector3(0, 90, 0);
		}else if(x == 0 && z == -1){
			visualPacman.transform.localEulerAngles = new Vector3(0, 270, 0);
		}else if(x == -1 && z == 0){
			visualPacman.transform.localEulerAngles = new Vector3(0, 0, 0);
		}else if(x == 1 && z == 0){
			visualPacman.transform.localEulerAngles = new Vector3(0, 180, 0);
		}
	}
//-----------------Return dX---------------------------
	public float ReturnDirectionX(){
		//körs från Ability Scripten för att avgöra riktningar
		return dX; 
	}
//----------------Return dZ------------------------
	public float ReturnDirectionZ(){
		//körs från Ability Scripten för att avgöra riktningar
		return dZ; 
	}
	public void directionFromAbility(){

		DontMoveMethod();

	}
}
