using UnityEngine;
using System.Collections.Generic;
//Varm välkommen till detta script, kul att du är här. Det här scriptet är till för att se till att plattor faller när PacMan gått över dem. Scriptet lägger du på ett tomt GameObject som sen har ett antal
// GameObjects under sig, barn, som är brodelar. Scriptet har koll på hur många broar du har på plan så länge broarna är under samma GameObjectet. När PacMan gått över en bro har alla delar av
// bron trillat ner. Scriptet kollar varje gång en bro har ramlat ifall den ska återställa en bro. Det är 40% chans att en bro kommer tillbaka, men en bro kan aldrig återställa sig själv. 
//Jag använder mig av arrayer som jag samlar de olika gameobjecten i. Varje bro har samma mamma. Alla barnen till mammorna har i sin tur ett script som säger till när den blivit träffad av PacMan.

public class FloatingBridges : MonoBehaviour {

	private GameObject[] child_BridgePieceCollider; //I dessa arrayer samlar jag information om alla broar som jag vet att kommer behöva.
	private Vector3[] originalPositions;
	private Quaternion[] originalRotation;
	private GameObject[] mySiblings;
	private static List<int> downedBridges;//denna fick bli en List för att antalet kommer variera och List är enkla att variera längden på.

	private Material bridgeMaterial;
	private Material bridgeDownMaterial;

	private bool needHelp; //<--Denna bool blir true om en annan bro har fallit, alltså inte mamman som har scriptet på sig.
	private bool bridgeDown;//<--Denna blir true om mamman med scriptet på sig nyss fallit.

	private int howManyKids; //Antalet barn, brodelar.

	private int piecesDown; //Jag använder den här för att scriptet ska veta när den har tappat alla sina delar. När pieces down är lika många som howManyKids vet man att bron har ramlat ner.
	private int myNumber;//mamman har en massa syskon. Vi vill veta vilken plats hon har i mySiblings arrayn.


	void Start () {

		bridgeMaterial = Resources.Load("W2_ElsaBridge") as Material;
		bridgeDownMaterial = Resources.Load("Nothing") as Material;

		howManyKids = gameObject.transform.childCount;

		child_BridgePieceCollider = new GameObject[howManyKids];
		originalPositions = new Vector3[howManyKids];
		originalRotation = new Quaternion[howManyKids];
		mySiblings = new GameObject[gameObject.transform.parent.gameObject.transform.childCount];
		downedBridges = new List<int>();




		for(int i = 0; i < child_BridgePieceCollider.Length; i++) //for loopar är bra att använda när det är ett antal object som ska in i en array. Jag har gjort så att alla object åker in utan att 
		{                                                           //behöva göra nått själv.
			child_BridgePieceCollider[i] = gameObject.transform.GetChild(i).gameObject;
			originalPositions[i] = child_BridgePieceCollider[i].gameObject.transform.GetChild(0).gameObject.transform.position;
			originalRotation[i] = child_BridgePieceCollider[i].gameObject.transform.GetChild(0).gameObject.transform.rotation;
		}
	
		for(int i = 0; i < gameObject.transform.parent.gameObject.transform.childCount; i++)
		{
			mySiblings[i] = (gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject);
		}
			
		piecesDown = 0;

		bridgeDown = false;

		WhoAmI(); //Kollar vilken plats mamman har i mySiblings arrayn.
	}

	public void LetItFall(int o) //Denna metod anropar barnen när de faller. När alla barn ramlat kommer den kolla ifall någon bro ska räddas.
	{
		if(bridgeDown == false)
		{
			child_BridgePieceCollider[o].gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = bridgeDownMaterial; // Materialet försvinner så att bron inte syns.
		child_BridgePieceCollider[o].gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Emit(50);

		piecesDown++;

		if(piecesDown == howManyKids)
		{
			
			bridgeDown = true;
			if(WillISaveSome1())
			{
			SavingPrivateBridge(); //Om en bro ska räddas kommer denna metod köras.
			}
		}
	}
	}
	private bool WillISaveSome1() //Ganska enkelt, ifall variabeln random blir något under 40 kommer true att retuneras.
	{
		int random;

		random = Random.Range(1,100);

		if(random < 40)
		{
			return(true);
		}
		else
		{
			return(false);
		}
	}

	public void SavingPrivateBridge() // Här måste man kolla vilka broar som är nere. De som visar att de är nere kommer hamna i en lista.
	{

		for(int i = 0; i < mySiblings.Length; i++)
		{
			
			needHelp = mySiblings[i].GetComponent<FloatingBridges>().MyStatus();


			if(needHelp == true && i != myNumber) //Sitt eget nummer hamnar inte i listan.
			{
				downedBridges.Add(i);
			}
		}
			
		mySiblings[downedBridges[Random.Range(0, downedBridges.Count)]].GetComponent<FloatingBridges>().TheChosenOne(); //En väljs ut av de som har fallit.
		downedBridges.Clear();
	}

	void TheChosenOne() //När en bro blir räddad vill vi att den inte säger att den fallit längre. BeamMeUp kommer köras för varje barn, brodel.
	{
		bridgeDown = false;

		for(int i = 0; i < child_BridgePieceCollider.Length; i++)
		{
			BeamMeUp(i);
		}
	}
	void BeamMeUp(int o) //Här gör jag så att brodelarna inte blir påverkade av gravity och blir kinematic.
	{
		child_BridgePieceCollider[o].gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = bridgeMaterial;

		child_BridgePieceCollider[o].gameObject.transform.GetChild(0).transform.position = originalPositions[o]; // brodelarna har fått sina ursprungliga värden för position och rotation sparade, som de nu
		child_BridgePieceCollider[o].gameObject.transform.GetChild(0).transform.rotation = originalRotation[o]; //blir återställde till.
	}
	public bool MyStatus()
	{
		return(bridgeDown);
	}
	void WhoAmI() //Här tar vi reda på vilken plats i mySiblings mamman har. 
	{
		for(int i = 0; i < mySiblings.Length; i++)
		{
			string name;

			name = mySiblings[i].name;
		
			if(name == gameObject.name)
			{
				myNumber = i;
			}
		}
	}

}
