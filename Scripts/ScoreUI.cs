using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text _scoreTxt;
	private float _score;

	private void Start()
	{
		_scoreTxt.text = "";
	}
	private void Update()
	{
		_score += Time.deltaTime;
		string textScore = Mathf.RoundToInt(_score).ToString();
		switch (textScore.Length)
		{
			case 1:
				_scoreTxt.text = "0000" + textScore;
				break;
			case 2:
				_scoreTxt.text = "000" + textScore;
				break;
			case 3:
				_scoreTxt.text = "00" + textScore;
				break;
			case 4:
				_scoreTxt.text = "0" + textScore;
				break;
			default:
				_scoreTxt.text = textScore;
				break;
		}
		
	}

}
