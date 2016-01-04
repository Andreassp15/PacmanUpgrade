using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public AudioSource eatGold;
	public AudioSource eatCourage;
	public AudioSource eatPowerCharge;
	public AudioSource eatDiamond;

	public AudioSource ghostDied;
	public AudioSource ghostHuntActivated;
	public AudioSource ghostFleeActivated;

	public AudioSource pacmanTeleport;
	public AudioSource pacmanRespawn;
	public AudioSource pacmanDied;
	public AudioSource pacmanActivatePower;
	public AudioSource pacmanHitPoison;

	public AudioSource gameOver;
	public AudioSource victory;
	public AudioSource pause;

	public AudioSource fireArrow;
	public AudioSource explosion;

	public AudioSource fireOrbCanon;
	public AudioSource buttonPress;
	public AudioSource elsaJump;
	public AudioSource elsaTalkAttack;
	public AudioSource elsaIceSpike;
	public AudioSource elsaDied;
	public AudioSource bridgeDestroyed;
	public AudioSource trollToss;
	public AudioSource trollBombExplode;
	public AudioSource trollTalk;

	public AudioSource backgroundMusic;

	public AudioSource abilityReady;
	public AudioSource abilityNotReady;

	public AudioSource shieldToss;
	public AudioSource shieldHitWall;
	public AudioSource shieldReturned;
	public AudioSource magnetEnlarge;
	public AudioSource magnetShrink;
	public AudioSource magnetHitExplosive;
	public AudioSource magnetHitGhost;
	public AudioSource decoyUsed;
	public AudioSource decoyFound;
	public AudioSource decoyEnlarge;
	public AudioSource decoyExplode;

	void Start () {
	
	}
	public void EatGoldMethod(){
		eatGold.Play();
	}
	public void EatCourageMethod(){
		eatCourage.Play();
	}
	public void EatPowerChargeMethod(){
		eatPowerCharge.Play();
	}
	public void EatDiamondMethod(){
		eatDiamond.Play();
	}
	public void GhostDiedMethod(){
		ghostDied.Play();
	}
	public void GhostHuntActivatedMethod(){
		ghostHuntActivated.Play();
	}
	public void GhostFleeActivatedMethod(){
		ghostFleeActivated.Play();
	}
	public void PacmanteleportMethod(){
		pacmanTeleport.Play();
	}
	public void PacmanRespawnMethod(){
		pacmanRespawn.Play();
	}
	public void PacmanDiedMethod(){
		pacmanDied.Play();
	}
	public void PacmanActivatePowerMethod(){
		pacmanActivatePower.Play();
	}
	public void PacmanHitPoison(){
		pacmanHitPoison.Play();
	}
	public void GameOverMethod(){
		gameOver.Play();
	}
	public void VictoryMethod(){
		victory.Play();
	}
	public void PauseMethod(){
		pause.Play();
	}
	public void FireArrowMethod(){
		fireArrow.Play();
	}
	public void ExplosionMethod(){
		explosion.Play();
	}
	public void FireOrbCanonMethod(){
		fireOrbCanon.Play();
	}
	public void ButtonPressMethod(){
		buttonPress.Play();
	}
	public void ElsaJumpMethod(){
		elsaJump.Play();
	}
	public void ElsaTalkAttackMethod(){
		elsaTalkAttack.Play();
	}
	public void ElsaIceSpikeMethod(){
		elsaIceSpike.Play();
	}
	public void ElsaDiedMethod(){
		elsaDied.Play();
	}
	public void BridgeDestroyedMethod(){
		bridgeDestroyed.Play();
	}
	public void TrollTossMethod(){
		trollToss.Play();
	}
	public void TrollBombExplodeMethod(){
		trollBombExplode.Play();
	}
	public void TrollTalk(){
		trollTalk.Play();
	}
	public void BackgroundMusicMethod(){
		backgroundMusic.Play();
	}
	public void AbilityReadyMethod(){
		abilityReady.Play();
	}
	public void AbilityNotReadyMethod(){
		abilityNotReady.Play();
	}
	public void ShieldTossMethod(){
		shieldToss.Play();
	}
	public void ShieldHitWall(){
		shieldHitWall.Play();
	}
	public void ShieldReturnedMethod(){
		shieldReturned.Play();
	}
	public void MagnetEnlargeMethod(){
		magnetEnlarge.Play();
	}
	public void MagnetShrinkMethod(){
		magnetShrink.Play();
	}
	public void MagnetHitExplosiveMethod(){
		magnetHitExplosive.Play();
	}
	public void MagnetHitGhostMethod(){
		magnetHitGhost.Play();
	}
	public void DecoyUsedMethod(){
		decoyUsed.Play();
	}
	public void DecoyFoundMethod(){
		decoyFound.Play();
	}
	public void DecoyEnlargeMethod(){
		decoyEnlarge.Play();
	}
	public void DecoyExplodeMethod(){
		decoyExplode.Play();
	}

	/*
	shiledRotate
	meteors
	arrows
	powerActive
	ghost
	*/




	

	void Update () {
	
	}
}
