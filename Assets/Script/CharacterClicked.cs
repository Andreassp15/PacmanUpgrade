using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterClicked : MonoBehaviour
{
	private GameObject[] charList; //Här kommer alla knappar för karaktärer att läggas i en lista. Det finns andra saker förutom karaktärerna men det är räknat med.
	private GameObject storage;


	void Start()
	{
		charList = new GameObject[5];

		for(int i = 0; i < charList.Length; i++)
		{
			charList[i] = transform.parent.transform.GetChild(i).gameObject; // första platsen, 0, blir en panel och sen kommer karaktärerna på plats 1, 2, 3. 
		}

		storage = GameObject.Find("SelectionInfo"); // Detta object har information om vilken gubbe som är vald och vilken bana som är vald att spela. 

	}


	public void CharacterSelected() //För att avgöra vilken gubbe som blev vald går denna metod igenom listan med karaktärer och när den hamnat på den plats i
	{								//listan som har samma namn som sitt eget gameobject tar den det numret att säger att det är gubben.
		string name;

		for(int i = 0; i < charList.Length; i ++)
		{
			name = charList[i].name;

			if(name == gameObject.name)
			{
				storage.GetComponent<SelectionInfo>().SelectedCharacter(i);
			}
		}

		if(storage.GetComponent<SelectionInfo>().WasNewGameSelected() == true) //Om spelaren inte valde level select i huvudmenyn ska spelet ladda första banan.
		{
			SceneManager.LoadScene("Map_1");
		}
		else
		{
			SceneManager.LoadScene(storage.GetComponent<SelectionInfo>().WhatLevelSelected()); //valde spelaren level select laddar spelet vilken bana spelaren valde efter att ha valt gubbe.
		}
	}
}
