using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ValAvBana : MonoBehaviour
{
    public GameObject Sub1, Sub2; // Detta är tre gameobjects som aktiveras på och av för att vissa vissa banor i taget när man väljer bana.
    private bool toggle1, toggle2, toggle3 = false;
	private List<string> buttons; // Alla knappar som representerar en bana läggs i denna lista.

	private string buttonClicked; //En metod från en annan klass som sitter på alla knapparna för banorna ger denna variabel en string som representerar banan som var vald.

	private GameObject storage; // Denna variabel är ett gameobject där vi berättar vilken bana som är vald. 
   


    public void Start()
    {
		buttons = new List<string>();

		for(int i = 0; i < 15; i++) // här lägger vi alla knapparna i listan, varför det sker två gånger är för att alla knappar ligger under två olika gameobjects.
		{
			buttons.Add(transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.name);
		}
		for(int i = 0; i < 15; i++)
		{
			buttons.Add(transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.name);
		}
		storage = GameObject.Find("SelectionInfo");




    }

    public void World1() // Dessa metoder är till för att sätta på och av de olika världarna när man väljer bana.
    {
        if(!toggle1)
        {
            Sub1.SetActive(true);
            Sub2.SetActive(false);
            toggle1 = true;
            toggle2 = false;
            toggle3 = false;
        }

        else
        {
            Sub1.SetActive(false);
            Sub2.SetActive(false);
            toggle1 = false;
        }   
    }

    public void World2()
    {
        if (!toggle2)
        {
            Sub1.SetActive(false);
            Sub2.SetActive(true);
            toggle1 = false;
            toggle2 = true;
            toggle3 = false;
        }

        else
        {
            Sub1.SetActive(false);
            Sub2.SetActive(false);
            toggle2 = false;
        }
    }

	public void SelectMap() //Här avgörs vilken bana som valdes. Den gämför namnet som knappen gav oss med namnen i listan. När två namn matchar i for loopen används värdet på i som nr på banan.
	{

		for(int i = 0; i < buttons.Count; i++)
		{

			if(buttons[i] == buttonClicked)
			{

				storage.GetComponent<SelectionInfo>().SelectedLevel("Map_" + (i + 1).ToString()); // i adderas med ett för att en lisa börjar på 0 och våra banor börjar med 1.
				SceneManager.LoadScene("Char_Val");
			}
		}
	}

	public void WhoIsClicked(string o)
	{
		buttonClicked = o;
	}


    public void Startmeny()
    {
		SceneManager.LoadScene("Startmeny");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
