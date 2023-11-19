using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int hp;
	public int currentLevel;
	bool hasWon;
	public List<string> levels;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void Win()
	{
		if (hasWon) return;

		hasWon = true;
		currentLevel++;
		Invoke("LoadNextScene",1f);
	}

	void LoadNextScene()
	{
		var levelName = levels[currentLevel];
		SceneManager.LoadScene(levelName);
		hasWon = false;
	}

	public void Lose()
	{
		// restart level and decrease hp
		// or restart game from zero
	}
}