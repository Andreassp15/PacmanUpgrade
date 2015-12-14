using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartVal : MonoBehaviour
{
    public void StartaSpel()
    {
        Application.LoadLevel("Char_Val");
    }

    public void Options()
    {
        Application.LoadLevel("Options");
    }

    public void Highscore()
    {
        Application.LoadLevel("Highscore");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
