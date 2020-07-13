using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private GameObject _volumeSlider;
    public void VolumeChange()
	{
		float volume = _volumeSlider.GetComponent<Slider>().value;
		SoundManager.Instance.ChangeVolume(volume);
	}

	public void BackButton()
	{
		UIManager.Instance.ControllOptionsUI(false);
		UIManager.Instance.ControllPauseUI(true);
	}
}
