using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	private static SoundManager _instance;
	public static SoundManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("Sound Manager is null");

			return _instance;
		}
	}

	AudioSource audioSource;

	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}

	public void ChangeVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
