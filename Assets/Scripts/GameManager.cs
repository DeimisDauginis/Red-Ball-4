using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int hp;
	public int currentLevel;
	bool hasWon;
	public List<string> levels;

	float targetTransitionScale;
	public Transform transition;

	AudioSource source;
	public AudioClip winSound;
	public AudioClip loseSound;
	public AudioClip gameOverSound;

	void Start()
	{
		source = GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);

		// destroys the game manager if there is another one
		if(  FindObjectsOfType<GameManager>().Length > 1)
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		var targetV3 = Vector3.one * targetTransitionScale;
		transition.localScale = Vector3.MoveTowards(transition.localScale,targetV3,60 * Time.deltaTime);
	}

	public void Win()
	{
		if (hasWon) return;

		hasWon = true;
		currentLevel++;
		targetTransitionScale = 30;
		Invoke("LoadNextScene",1f);

		source.PlayOneShot(winSound);
	}

	void LoadNextScene()
	{
		var levelName = levels[currentLevel];
		SceneManager.LoadScene(levelName);
		hasWon = false;
		targetTransitionScale = 0;
	}


	public void Lose()
	{
		hp--;
		if (hp > 0)
		{
			source.PlayOneShot(loseSound);
			Invoke("LoadNextScene",1f);
		}
		else
		{
			source.PlayOneShot(gameOverSound);
			currentLevel = 0;
			hp = 3;
			Invoke("LoadNextScene",1f);
		}
	}
}