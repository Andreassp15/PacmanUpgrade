using UnityEngine;
using System.Collections.Generic;


public class ElsaController : MonoBehaviour {

	private GameObject pacman;

	private Vector3 fwd;

	private Vector3 jumpSpeed;
	public float rotationSpeed;

	private float time;

	public Transform[] jumpTargets;
	private int target;
	private int currentPosision;
	private int lastTarget;

	private int jumpsDoneInSession;
	private int jumpsBeforeAttack;
	private int fireCheckpointsLit;

	private float rotationInput;
	protected float jumpInput;

	protected bool canJump;
	private bool needNewTarget;
	private bool targetSighted;
	private bool inPosition;
	private bool attacking;

	private float iceSpikeGo;
	private bool spikeTargetSet;
	private GameObject[] iceSpikes;
	public GameObject iceSpikeDady;
	public ParticleSystem warning;

	private List<GameObject> bridgesList;

	private GameObject bridgeMama;

	private Animator elsaAnimator;

	private List<GameObject> fireCheckpoints;

	private AudioClip[] music;
	private AudioSource speaker;





	void Start()
	{
		iceSpikes = new GameObject[4];

		music = new AudioClip[2];

		music[0] = Resources.Load<AudioClip>("Boss2") as AudioClip;
		music[1] = Resources.Load<AudioClip>("Boss2") as AudioClip;

		fireCheckpoints = new List<GameObject>();

		speaker = transform.parent.gameObject.GetComponent<AudioSource>();

		speaker.clip = music[0];
		speaker.volume = 0.35f;
		speaker.Play();

		for(int i = 0; i < 8; i++)
		{
			fireCheckpoints.Add(transform.parent.GetChild(1).GetChild(i).gameObject);
		}
		for(int i = 0; i < 4; i++)
		{
			iceSpikes[i] = transform.parent.GetChild(i + 2).gameObject;
			iceSpikes[i].transform.GetChild(0).gameObject.SetActive(false);
		}

		fireCheckpointsLit = 0;

		elsaAnimator = transform.GetChild(0).GetComponent<Animator>();

		pacman = GameObject.FindGameObjectWithTag("Pacman");

		bridgeMama = GameObject.Find("AllBridges");
		bridgesList = new List<GameObject>();

		for(int i = 0; i < bridgeMama.transform.childCount; i++)
		{
			bridgesList.Add(bridgeMama.transform.GetChild(i).transform.gameObject);
		}

		time = 0f;

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
		attacking = false;

		currentPosision = 0;
	
		target = 1;

	}

	void FixedUpdate()
	{
			if(canJump == true)
			{
			DarkElsaJump();
			}
		if(jumpsDoneInSession == jumpsBeforeAttack)
		{
			transform.position = Vector3.Lerp(transform.position, jumpTargets[target].transform.position, 3.0f * Time.deltaTime);
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



				if(Vector3.Distance(transform.position, jumpTargets[target].transform.position) < 0.5f && attacking == false)
					{
										if(fireCheckpointsLit < 5)
											{
											IceSpikeAttack();
											}
										else
											{
											MultiSpikeAttack();
											}
					}
			}
			else
			{
				jumpsBeforeAttack = 1;
				jumpsDoneInSession = 0;
			}
		}
											if(transform.position.y <  12.0f) // om bossen skulle missa sitt mål och faller under 12 grader på y axel kommer hon teleporteras till närmaste plattform.
											{
												float dist;

												for(int i = 0; i < jumpTargets.Length; i++)
												{
													dist = Vector3.Distance(transform.position, jumpTargets[i].transform.position);


													if(dist < 10.0f)
													{
														transform.position = jumpTargets[i].transform.position;
														break;
													}
												}
											}

	}


	private Vector3 CalculateVel(Vector3 origin, Vector3 target, float timeToTarget) // Denna metod räknar ut den kraft som behövs för att skjuta ett object till en plats.
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
	private void ChoseTarget() //Denna metod är för att välja en platform att hoppa till.
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

	private void DarkElsaJump() // För att röra bossen använder vi force.
	{
		elsaAnimator.Play("Take 001");

		GetComponent<Rigidbody>().isKinematic = false;

		jumpSpeed =  CalculateVel(transform.position, jumpTargets[target].position, 1f);
		GetComponent<Rigidbody>().AddForce(jumpSpeed, ForceMode.VelocityChange);

		canJump = false;


	}
	private void DarkElsaRotate(Vector3 newDirection) // bossen roterar fult men det duger.
	{
		transform.LookAt(newDirection);
	}


	private void IsTouchDown()// när bossen landar ska den bli kinematic igen.
	{
		if(transform.position.y - jumpTargets[target].transform.position.y < 0.5f && Vector3.Distance(transform.position, jumpTargets[target].transform.position) < 3.0f)
		{
			elsaAnimator.Play("Take 0011");

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
		if(spikeTargetSet == false && attacking == false)
		{
			elsaAnimator.Play("Take 001 0");
			iceSpikes[0].transform.GetChild(2).gameObject.SetActive(true);
			iceSpikes[0].gameObject.transform.position = pacman.gameObject.transform.position;
			attacking = true;
			spikeTargetSet = true;

			Invoke("IceSpikeSpawn", Random.Range(0.5f, 0.9f));
		}
	}
	private void IceSpikeSpawn()
	{
		foreach(GameObject t in iceSpikes)
		{
			t.transform.GetChild(0).gameObject.SetActive(true);
			t.transform.GetChild(2).gameObject.SetActive(false);
		}
		spikeTargetSet = false;

		Invoke("ReSetJumps", 1.5f);
	}
	private void MultiSpikeAttack()
	{
		float minDist = Mathf.Infinity;

		elsaAnimator.Play("Take 001 0");

		GameObject closestFireCheckpoint = new GameObject();

		attacking = true;

		foreach (GameObject t in fireCheckpoints)
		{
			float dist = Vector3.Distance(pacman.transform.position, t.transform.position);
			if(dist < minDist)
			{
				closestFireCheckpoint = t;

				minDist = dist;
			}
		}

		closestFireCheckpoint.GetComponent<Fire_Checkpoints>().MultiSpikeAttack();

		Invoke("IceSpikeSpawn", Random.Range(0.5f, 0.9f));

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
	public void ReSetJumps()
	{
			jumpsDoneInSession = 0;
			jumpsBeforeAttack = Random.Range(5,9);
			attacking = false;

	}
	public void AddFireCheckpoint()
	{
		fireCheckpointsLit++;
	}

	public void ChangeMusic(bool o)
	{
		if(o == true);
		{
			speaker.clip = music[1];
			speaker.Play();
		}
			
	}

				
}
