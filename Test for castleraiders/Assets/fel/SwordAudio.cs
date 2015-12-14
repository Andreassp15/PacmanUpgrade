using UnityEngine;
using System.Collections;

public class SwordAudio : MonoBehaviour {


	public AudioClip swordHit;
	public float volume = 0.25f;
	void Start () {
	
	}

	public void HitWithSword()
	{
		AudioSource.PlayClipAtPoint(swordHit, transform.position,volume);


	}
}