using UnityEngine;
using System.Collections;

public class ElsaController : MonoBehaviour {

	private Vector3 jumpSpeed;
	public float rotationSpeed;

	public Transform[] jumpTargets;
	private int jumpTargetIndex;

	CharacterController cc;

	private float rotationInput;
	protected float jumpInput;

	protected bool jump;

	protected Vector3 gravity = Vector3.zero;
	protected Vector3 move;

	void Start()
	{
		
		move = Vector3.zero;
		rotationInput = 0;
		jumpInput = 0;
		jump = true;


		jumpTargetIndex = 1;

	}

	void FixedUpdate()
	{

		//Vector3 forward = jumpInput * CalculateVel(transform.position, jumpTargets[jumpTargetIndex], 1.0f);
		//transform.Rotate(new Vector3(0f, rotationInput * rotationSpeed * Time.deltaTime, 0f));
		//cc.Move(forward * Time.deltaTime);
		//cc.SimpleMove(Physics.gravity);

	
			if(Input.GetKeyDown(KeyCode.Space) && jump == true)
			{
				Debug.Log("space");
				jumpSpeed =  CalculateVel(transform.position, jumpTargets[jumpTargetIndex].position, 1.0f);

				Debug.Log(jumpSpeed.ToString());

				GetComponent<Rigidbody>().AddForce(jumpSpeed, ForceMode.VelocityChange);

				jump = false;
			}
		}


	private Vector3 CalculateVel(Vector3 origin, Vector3 target, float timeToTarget)
	{
		Vector3 toTarget = target - origin;
		Vector3 toTargetXZ = toTarget;

		toTargetXZ.y = 0;

		float y = toTarget.y;
		float xz = toTargetXZ.magnitude;

		float t = timeToTarget;

		float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
		float v0xz = xz / t;

		Vector3 result = toTargetXZ.normalized;
		result *= v0xz;

		result.y = v0y;

		return result;
	}

}
