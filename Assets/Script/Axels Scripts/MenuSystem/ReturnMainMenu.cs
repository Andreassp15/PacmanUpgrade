using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour {

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("Startmeny");
	}
	public void Quit()
	{
		Application.Quit();
	}
}
