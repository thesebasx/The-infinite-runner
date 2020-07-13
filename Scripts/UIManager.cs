using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
	{
		get
		{
            if (_instance == null)
                Debug.LogError("UI Manager is null");

            return _instance;
		}
	}

    [SerializeField] private GameObject _gameOverUI;
	[SerializeField] private GameObject _pauseUI;
	[SerializeField] private GameObject _optionsUI;

	private void Awake()
	{
        _instance = this;
	}
	
	public void ActivateGameOverUI()
	{
		_gameOverUI.SetActive(true);
	}

	public void ControllPauseUI(bool active)
	{
		_pauseUI.SetActive(active);
	}

	public void ControllOptionsUI(bool active)
	{
		if(_pauseUI.activeSelf == true)
		{
			ControllPauseUI(false);
		}
		_optionsUI.SetActive(active);
	}
    
}
