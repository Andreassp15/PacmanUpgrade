using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	float moveSpeed = 0.1f;

	public KeyCode forward;
	public KeyCode backwards;
	public KeyCode left;
	public KeyCode right;

	RaycastHit frontRayHit1;
	RaycastHit frontRayHitMiddle;
	RaycastHit frontRayHit2;

	RaycastHit leftRayHit1;
	RaycastHit leftRayHitMiddle;
	RaycastHit leftRayHit2;

	RaycastHit rightRayHit1;
	RaycastHit rightRayHitMiddle;
	RaycastHit rightRayHit2;

	RaycastHit backRayHit1;
	RaycastHit backRayHitMiddle;
	RaycastHit backRayHit2;

	bool frontRayBool1 = true;
	bool frontRayBoolMiddle = true;
	bool frontRayBool2 = true;

	bool leftRayBool1 = true;
	bool leftRayBoolMiddle = true;
	bool leftRayBool2 = true;

	bool rightRayBool1 = true;
	bool rightRayBoolMiddle = true;
	bool rightRayBool2 = true;

	bool backRayBool1 = true;
	bool backRayBoolMiddle = true;
	bool backRayBool2 = true;

	Vector3 frontCheck;
	Vector3 leftCheck;
	Vector3 rightCheck;
	Vector3 backCheck;

	Vector3 offsetPosition1 = new Vector3(0.999f, 0f, 0f);
	Vector3 offsetPosition2 = new Vector3(0f, 0f, 0.999f);

	float rayLength = 1.10f;

	float directionX;
	float directionZ;
	float savedDirectionX;
	float savedDirectionZ;
	Vector3 direction;

	void Start () {
		directionX = 1f;

		frontCheck = transform.TransformDirection(Vector3.forward);
		leftCheck = transform.TransformDirection(Vector3.left);
		rightCheck = transform.TransformDirection(-Vector3.left);
		backCheck = transform.TransformDirection(-Vector3.forward);
	
	}

	void Update () {

		RayCasterMethod();

		//transform.Translate(direction * moveSpeed);
		direction = new Vector3(directionX, 0, directionZ);
		transform.Translate(direction * moveSpeed);

		if(Input.GetKeyDown(forward)){
			if(frontRayBool1 == true && frontRayBool2 == true && frontRayBoolMiddle == true){
				directionX = 0;
				directionZ = 1;
			}else{
				savedDirectionX = 0;
				savedDirectionZ = 1;
			}

			//transform.Translate(Vector3.forward * moveSpeed);
		}
		if(directionX == 0 && directionZ == 1){
			if(frontRayBool1 == true && frontRayBool2 == true && frontRayBoolMiddle == true){
				moveSpeed = 0.1f;
			}else{
				moveSpeed = 0f;
			}
		}/*else if(savedDirectionX == 0 && savedDirectionZ == 1){
			if(frontRayBool1 == true && frontRayBool2 == true && frontRayBoolMiddle == true){
				directionX = 0;
				directionZ = 1;
			}
		}*/

		if(Input.GetKeyDown(backwards)){
			if(backRayBool1 == true && backRayBool2 == true && backRayBoolMiddle == true){
				directionX = 0;
				directionZ = -1;
			}else{
				savedDirectionX = 0;
				savedDirectionZ = -1;
			}

			Debug.Log(direction);
			//transform.Translate(-Vector3.forward * moveSpeed);
		}
		if(directionX == 0 && directionZ == -1){
			if(backRayBool1 == true && backRayBool2 == true && backRayBoolMiddle == true){
				moveSpeed = 0.1f;
			}else{
				moveSpeed = 0f;
			}
		}/*else if(savedDirectionX == 0 && savedDirectionZ == -1){
			if(backRayBool1 == true && backRayBool2 == true && backRayBoolMiddle == true){
				directionX = 0;
				directionZ = -1;
			}
		}*/


		if(Input.GetKey(left)){
			if(leftRayBool1 == true && leftRayBool2 == true && leftRayBoolMiddle == true){
				directionX = -1;
				directionZ = 0;

			}else{
				savedDirectionX = -1;
				savedDirectionZ = 0;
			}

			//transform.Translate(Vector3.left * moveSpeed);
		}
		if(directionX == -1 && directionZ == 0){
			if(leftRayBool1 == true && leftRayBool2 == true && leftRayBoolMiddle == true){
				moveSpeed = 0.1f;
			}else{
				moveSpeed = 0f;
			}
		}/*else if(savedDirectionX == -1 && savedDirectionZ == 0){
			if(leftRayBool1 == true && leftRayBool2 == true && leftRayBoolMiddle == true){
				directionX = -1;
				directionZ = 0;
			}
		}*/
		if(Input.GetKey(right)){
			if(rightRayBool1 == true && rightRayBool2 == true && rightRayBoolMiddle == true){
				directionX = 1;
				directionZ = 0;
			}else{
				savedDirectionX = 1;
				savedDirectionZ = 0;
			}

			//transform.Translate(Vector3.right * moveSpeed);
		}
		if(directionX == 1 && directionZ == 0){
			if(rightRayBool1 == true && rightRayBool2 == true && rightRayBoolMiddle == true){
				moveSpeed = 0.1f;
			}else{
				moveSpeed = 0f;
			}

		}/*else if(savedDirectionX == 1 && savedDirectionZ == 0){
			if(rightRayBool1 == true && rightRayBool2 == true && rightRayBoolMiddle == true){
				directionX = 1;
				directionZ = 0;
			}
		}*/

	}
	void RayCasterMethod(){
//--------------------------Front RayCast  1, 2 , middle---------------------------------------------------
		if(Physics.Raycast(transform.position + offsetPosition1, frontCheck, out frontRayHit1, rayLength)){
			if(frontRayHit1.transform.tag == "wall"){
				frontRayBool1 = false;
				//Debug.Log("front1 hit wall");
			}
		}else{
			frontRayBool1 = true;
		}
		if(Physics.Raycast(transform.position - offsetPosition1, frontCheck, out frontRayHit2, rayLength)){
			if(frontRayHit2.transform.tag == "wall"){
				frontRayBool2 = false;
				//Debug.Log("front2 hit wall");
			}
		}else{
			frontRayBool2 = true;
		}
		if(Physics.Raycast(transform.position, frontCheck, out frontRayHitMiddle, rayLength)){
			if(frontRayHitMiddle.transform.tag == "wall"){
				frontRayBoolMiddle = false;
				//Debug.Log("frontmiddle hit wall");
			}
		}else{
			frontRayBoolMiddle = true;
		}
//--------------------------Left RayCast  1, 2 , middle---------------------------------------------------	
		if(Physics.Raycast(transform.position + offsetPosition2, leftCheck, out leftRayHit1, rayLength)){
			if(leftRayHit1.transform.tag == "wall"){
				leftRayBool1 = false;
				//Debug.Log("left hit wall");
			}
		}else{
			leftRayBool1 = true;
		}
		if(Physics.Raycast(transform.position - offsetPosition2, leftCheck, out leftRayHit2, rayLength)){
			if(leftRayHit2.transform.tag == "wall"){
				leftRayBool2 = false;
				//Debug.Log("left hit wall");
			}
		}else{
			leftRayBool2 = true;
		}
		if(Physics.Raycast(transform.position, leftCheck, out leftRayHitMiddle, rayLength)){
			if(leftRayHitMiddle.transform.tag == "wall"){
				leftRayBoolMiddle = false;
				//Debug.Log("left hit wall");
			}
		}else{
			leftRayBoolMiddle = true;
		}
//--------------------------Right RayCast  1, 2 , middle---------------------------------------------------
		
		if(Physics.Raycast(transform.position + offsetPosition2, rightCheck, out rightRayHit1, rayLength)){
			if(rightRayHit1.transform.tag == "wall"){
				rightRayBool1 = false;
				//Debug.Log("right hit wall");
			}
		}else{
			rightRayBool1 = true;
		}
		if(Physics.Raycast(transform.position -  offsetPosition2, rightCheck, out rightRayHit2, rayLength)){
			if(rightRayHit2.transform.tag == "wall"){
				rightRayBool2 = false;
				//Debug.Log("right hit wall");
			}
		}else{
			rightRayBool2 = true;
		}
		if(Physics.Raycast(transform.position, rightCheck, out rightRayHitMiddle, rayLength)){
			if(rightRayHitMiddle.transform.tag == "wall"){
				rightRayBoolMiddle = false;
				//Debug.Log("right hit wall");
			}
		}else{
			rightRayBoolMiddle = true;
		}
//--------------------------Back RayCast  1, 2 , middle---------------------------------------------------		
		if(Physics.Raycast(transform.position + offsetPosition1, backCheck, out backRayHit1, rayLength)){
			if(backRayHit1.transform.tag == "wall"){
				backRayBool1 = false;
				//Debug.Log("back hit wall");
			}
		}else{
			backRayBool1 = true;
		}
		if(Physics.Raycast(transform.position -  offsetPosition1, backCheck, out backRayHit2, rayLength)){
			if(backRayHit2.transform.tag == "wall"){
				backRayBool2 = false;
				//Debug.Log("back hit wall");
			}
		}else{
			backRayBool2 = true;
		}
		if(Physics.Raycast(transform.position, backCheck, out backRayHitMiddle, rayLength)){
			if(backRayHitMiddle.transform.tag == "wall"){
				backRayBoolMiddle = false;
				//Debug.Log("back hit wall");
			}
		}else{
			backRayBoolMiddle = true;
		}
	}

}
