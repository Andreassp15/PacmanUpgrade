using UnityEngine;
using System.Collections;

public class SelectionInfo : MonoBehaviour { //Denna klass har bara några värden som behövs senare så att spelet laddar rätt gubbe och rätt bana.

	public int charSelected;
	public string levelSelected;

	public int totalScore;

	private bool startNewGameSelected;

	void Start()
	{
		DontDestroyOnLoad(gameObject);

		totalScore = 0;

		startNewGameSelected = false;
	}
		
	public void SelectedCharacter(int o)
	{
		charSelected = o;
	}

	public void SelectedLevel(string o)
	{
		levelSelected = o;
	}

	public void SelectedNewGame(bool o)
	{
		startNewGameSelected = o;
	}
	public bool WasNewGameSelected()
	{
		return startNewGameSelected;
	}
	public string WhatLevelSelected()
	{
		return levelSelected;
	}
	public int WhatCharacter()
	{
		return charSelected;
	}
	public void TotalScore(int addScore)
	{
		totalScore = addScore;
	}
	public int WhatIsTheScore()
	{
		return totalScore;
	}
}
