using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TheyClickedMe : MonoBehaviour {

	private GameObject canvas;
	private GameObject storage;

	void Start()
	{
		canvas = GameObject.Find("Canvas");
		storage = GameObject.Find("SelectionInfo");
	}

	public void Clicked()
	{
		canvas.GetComponent<ValAvBana>().WhoIsClicked(gameObject.name);
	}

	public void SelectedNewGame()
	{
		storage.GetComponent<SelectionInfo>().SelectedNewGame(true);

		SceneManager.LoadScene("Char_Val");
	}
	public void LoadLevelSelection()
	{
		SceneManager.LoadScene("Bana_Val");
	}
}
