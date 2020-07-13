using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("Game Manager is null");

			return _instance;
		}
	}

	private bool _gameIsOver = false;
	private bool _gameIsPaused = false;

	private void Awake()
	{
		_instance = this;
	}

	private void Update()
	{
		if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (_gameIsPaused == false)
			{
				Time.timeScale = 0;
				UIManager.Instance.ControllPauseUI(true);
				_gameIsPaused = true;
			}
			else if (_gameIsPaused == true)
			{
				Time.timeScale = 1;
				UIManager.Instance.ControllPauseUI(false);
				UIManager.Instance.ControllOptionsUI(false);
				_gameIsPaused = false;
			}
		}
		
		
	}

	public void GameOver()
	{
		if (!_gameIsOver)
		{
			Time.timeScale = 0f;
			_gameIsOver = true;
			UIManager.Instance.ActivateGameOverUI();
		}
	}
}
