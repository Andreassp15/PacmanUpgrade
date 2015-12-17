using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject pauseCanvas;

	private GameObject sceneTag;

	void Start () {

		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(pauseCanvas);

		sceneTag = GameObject.FindGameObjectWithTag("Menu");

	}

	void Update () {		





	
		if(Input.GetKeyDown(KeyCode.Escape)) 
	{
			

																																			
			Time.timeScale = 0;

			pauseCanvas.SetActive(true);


	
	}

	}
	public void Resumel()
	{
		Debug.Log("click");
		Time.timeScale = 1;

		pauseCanvas.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();

	}
	public void MainMenu()
	{
		SceneManager.LoadScene("Startmeny");

		Destroy(gameObject);
	}
}
