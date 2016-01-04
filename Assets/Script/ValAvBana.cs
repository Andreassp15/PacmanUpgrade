using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValAvBana : MonoBehaviour
{
    public GameObject Sub1, Sub2, Sub3;
    private bool toggle1, toggle2, toggle3 = false;
   /* private string[] map = new string[30];
    private GameObject[] buttons;
   


    public void Start()
    {


        buttons = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 1; i < map.Length; i++)
        {
            map[i] = "Map_" + i.ToString();
        }
    }

    public void mapChoice()
    {
        Debug.Log(gameObject.name);
        
        for(int i = 1; i < buttons.Length; i++ )
        {
            //Debug.Log(buttons[i]);
            if(gameObject.name + " (UnityEngine.GameObject)" == buttons[i].name)
            {
                Application.LoadLevel(i);
            } else { Debug.Log(gameObject.name + " (UnityEngine.GameObject)" + "is not equal to" + buttons[i]); }

        }
        //Application.LoadLevel(gameObject.name);

       

        
        
    }*/

    public void World1()
    {
        if(!toggle1)
        {
            Sub1.SetActive(true);
            Sub2.SetActive(false);
            Sub3.SetActive(false);
            toggle1 = true;
            toggle2 = false;
            toggle3 = false;
        }

        else
        {
            Sub1.SetActive(false);
            Sub2.SetActive(false);
            Sub3.SetActive(false);
            toggle1 = false;
        }   
    }

    public void World2()
    {
        if (!toggle2)
        {
            Sub1.SetActive(false);
            Sub2.SetActive(true);
            Sub3.SetActive(false);
            toggle1 = false;
            toggle2 = true;
            toggle3 = false;
        }

        else
        {
            Sub1.SetActive(false);
            Sub2.SetActive(false);
            Sub3.SetActive(false);
            toggle2 = false;
        }
    }

    public void World3()
    {
        if (!toggle3)
        {
            Sub1.SetActive(false);
            Sub2.SetActive(false);
            Sub3.SetActive(true);
            toggle1 = false;
            toggle2 = false;
            toggle3 = true;
        }

        else
        {
            Sub1.SetActive(false);
            Sub2.SetActive(false);
            Sub3.SetActive(false);
            toggle3 = false;
        }
    }

    public void Startmeny()
    {
        Application.LoadLevel("Startmeny");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void bana1()
    {
        Application.LoadLevel("Map_1");
    }

    public void bana2()
    {
        Application.LoadLevel("Map_2");
    }

    public void bana3()
    {
        Application.LoadLevel("Map_3");
    }

    public void bana4()
    {
        Application.LoadLevel("Map_4");
    }

    public void bana5()
    {
        Application.LoadLevel("Map_5");
    }

    public void bana6()
    {
        Application.LoadLevel("Map_6");
    }

    public void bana7()
    {
        Application.LoadLevel("Map_7");
    }

    public void bana8()
    {
        Application.LoadLevel("Map_8");
    }

    public void bana9()
    {
        Application.LoadLevel("Map_9");
    }

    public void bana10()
    {
        Application.LoadLevel("Map_10");
    }

    public void bana11()
    {
        Application.LoadLevel("Map_11");
    }

    public void bana12()
    {
        Application.LoadLevel("Map_12");
    }

    public void bana13()
    {
        Application.LoadLevel("Map_13");
    }

    public void bana14()
    {
        Application.LoadLevel("Map_14");
    }

    public void bana15()
    {
        Application.LoadLevel("Map_15");
    }

    public void bana16()
    {
        Application.LoadLevel("Map_16");
    }

    public void bana17()
    {
        Application.LoadLevel("Map_17");
    }

    public void bana18()
    {
        Application.LoadLevel("Map_18");
    }

    public void bana19()
    {
        Application.LoadLevel("Map_19");
    }

    public void bana20()
    {
        Application.LoadLevel("Map_20");
    }

    public void bana21()
    {
        Application.LoadLevel("Map_21");
    }

    public void bana22()
    {
        Application.LoadLevel("Map_22");
    }

    public void bana23()
    {
        Application.LoadLevel("Map_23");
    }

    public void bana24()
    {
        Application.LoadLevel("Map_24");
    }

    public void bana25()
    {
        Application.LoadLevel("Map_25");
    }

    public void bana26()
    {
        Application.LoadLevel("Map_26");
    }

    public void bana27()
    {
        Application.LoadLevel("Map_27");
    }

    public void bana28()
    {
        Application.LoadLevel("Map_28");
    }

    public void bana29()
    {
        Application.LoadLevel("Map_29");
    }

    public void bana30()
    {
        Application.LoadLevel("Map_30");
    }

}
