using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValAvGubbe : MonoBehaviour
{
    public GameObject Pacman1;
    public GameObject Pacman2;
    public GameObject Pacman3;

    public void Char1()
    {
        DontDestroyOnLoad(Pacman1);
        Application.LoadLevel("Bana_Val");
    }

    public void Char2()
    {
        DontDestroyOnLoad(Pacman2);
        Application.LoadLevel("Bana_Val");
    }

    public void Char3()
    {
        DontDestroyOnLoad(Pacman3);
        Application.LoadLevel("Bana_Val");
    }

    public void Startmeny()
    {
        Application.LoadLevel("Startmeny");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
