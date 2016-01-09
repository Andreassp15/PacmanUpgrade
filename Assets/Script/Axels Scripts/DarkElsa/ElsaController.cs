using UnityEngine;
using System.Collections.Generic;


public class ElsaController : MonoBehaviour {

	private GameObject pacman;

	private Vector3 fwd;

	private Vector3 jumpSpeed;
	public float rotationSpeed;

	public Transform[] jumpTargets;
	private int target;
	private int currentPosision;
	private int lastTarget;

	private int jumpsDoneInSession;
	private int jumpsBeforeAttack;

	private float rotationInput;
	protected float jumpInput;

	protected bool canJump;
	private bool needNewTarget;
	private bool targetSighted;
	private bool inPosition;

	private float iceSpikeGo;
	private bool spikeTargetSet;
	public GameObject iceSpike;
	public GameObject iceSpikeDady;
	public ParticleSystem warning;

	private List<GameObject> bridgesList;

	private GameObject bridgeMama;





	void Start()
	{
		pacman = GameObject.FindGameObjectWithTag("Pacman");

		bridgeMama = GameObject.Find("AllBridges");
		bridgesList = new List<GameObject>();

		for(int i = 0; i < bridgeMama.transform.childCount; i++)
		{
			bridgesList.Add(bridgeMama.transform.GetChild(i).transform.gameObject);
		}


		lastTarget = 0;

		jumpsBeforeAttack = 5;

		fwd = transform.TransformDirection(Vector3.forward);

		jumpsDoneInSession = 0;

		rotationInput = 0;
		jumpInput = 0;
		canJump = true;

		needNewTarget = false;
		targetSighted = true;
		inPosition = false;

		currentPosision = 0;


		target = 1;

		iceSpikeGo = 0.3f;

		iceSpike.SetActive(false);

	}

	void FixedUpdate()
	{
			if(canJump == true)
			{
			DarkElsaJump();
			}
		if(jumpsDoneInSession == jumpsBeforeAttack)
		{
			transform.position = Vector3.Lerp(transform.position, jumpTargets[target].transform.position, 2.0f * Time.deltaTime);
		}
	}
	void Update()
	{
		if(jumpsDoneInSession < jumpsBeforeAttack)
		{
			DarkElsaRotate(jumpTargets[target].transform.position);


					if(needNewTarget == true)
					{
						ChoseTarget();


					}

			IsTouchDown();
		}
		else
		{
			
			if(Vector3.Distance(transform.position, pacman.transform.position) < 16.0f && PacmanInAir() == false)
			{



				if(Vector3.Distance(transform.position, jumpTargets[target].transform.position) < 0.5f)
						{
						IceSpikeAttack();
						}
			}
			else
			{
				jumpsBeforeAttack = 1;
				jumpsDoneInSession = 0;
			}
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
	private void ChoseTarget()
	{

		target = Random.Range(0, 4);

		bool checkOne = false;
		bool checkTwo = false;

		if(target == currentPosision)
		{
			ChoseTarget();
		}
		else
		{
		checkOne = true;

			if(target == lastTarget)
			{
				int random = Random.Range(0, 100);

				if(random <= 70)
				{
					ChoseTarget();
				}
				else
				{
					checkTwo = true;
				}
		
			}
			else
			{
				checkTwo = true;
			}

		}
		if(checkOne == true && checkTwo == true)
		{
			needNewTarget = false;
			targetSighted = false;
			canJump = true;


		}

	}

	private void DarkElsaJump()
	{
		GetComponent<Rigidbody>().isKinematic = false;

		jumpSpeed =  CalculateVel(transform.position, jumpTargets[target].position, 1f);
		GetComponent<Rigidbody>().AddForce(jumpSpeed, ForceMode.VelocityChange);

		canJump = false;


	}
	private void DarkElsaRotate(Vector3 newDirection)
	{
		transform.LookAt(newDirection);
	}


	private void IsTouchDown()
	{
		if(transform.position.y - jumpTargets[target].transform.position.y < 0.5f && Vector3.Distance(transform.position, jumpTargets[target].transform.position) < 3.0f)
		{
			

			jumpsDoneInSession++;

			GetComponent<Rigidbody>().isKinematic = true;

			needNewTarget = true;

			targetSighted = false;

			lastTarget = currentPosision;

			currentPosision = target;



		}
	}
	private void IceSpikeAttack()
	{
		iceSpikeGo = iceSpikeGo + Time.deltaTime;


		if(spikeTargetSet == false)
		{
			iceSpikeDady.gameObject.transform.position = pacman.gameObject.transform.position;
			warning.gameObject.SetActive(true);


			spikeTargetSet = true;
		}

		if(iceSpikeGo > 0.5f)
		{
			iceSpike.SetActive(true);
			warning.gameObject.SetActive(false);
			jumpsDoneInSession = 0;

			iceSpikeGo = 0;
			spikeTargetSet = false;

			jumpsBeforeAttack = Random.Range(5,11);
		}
	}
	private bool PacmanInAir()
				{
					bool verdict = new bool();


					for(int i = 0; i < bridgesList.Count; i++)
					{

						if(bridgesList[i].GetComponent<FloatingBridges>().IsPacmanInAir() == true)
						{
							verdict = true;

							break;
						}
						else
						{
							verdict = false;
						}

						
						}
					return verdict;

				}

				
}
