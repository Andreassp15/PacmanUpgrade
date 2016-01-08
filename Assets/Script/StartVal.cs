using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartVal : MonoBehaviour
{
    public void StartaSpel()
    {
		SceneManager.LoadScene("Bana_Val");
    }

    public void Options()
    {
		SceneManager.LoadScene("Option");
    }

    public void Highscore()
    {
		SceneManager.LoadScene("HighScore");
    }

    public void Quit()
    {
		Application.Quit();
    }
}
