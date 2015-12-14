using UnityEngine;
using System.Collections;

//**********************************************************
//scriptet till att bakgrnds musik och då pacman äter godis
//***********************************************************

public class Sound : MonoBehaviour {

	public AudioClip pacman;
	public AudioClip music;
	public AudioClip background;
	public AudioClip eatCandy;
	public AudioSource pacmanAudioSource;
	public AudioSource musicSource;
	public AudioSource backgroundAudioSource;
	public AudioSource eatCandySource;

	void Start () {
		pacmanAudioSource.clip = pacman;
		musicSource.clip = music;
		backgroundAudioSource.clip = background;
		eatCandySource.clip = eatCandy;
	}
	public void eatCandyMethod(){
		eatCandySource.Play();
	}

}
