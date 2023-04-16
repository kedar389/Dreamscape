using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
	public AudioSource audioSource;
	public bool isPlaying = false;

	void Start()
	{
	}

	public void SetSong(string path)
	{
		if (audioSource != null)
		{
			audioSource.Pause();
		}
		AudioClip clip = Resources.Load<AudioClip>(path);
		if (clip != null)
		{
			if (audioSource == null)
			{
				audioSource = gameObject.AddComponent<AudioSource>();
			}
			audioSource.clip = clip;
			onOff();
		}
	}

	public void onOff()
	{
		if (isPlaying) { 
			isPlaying = false;
			audioSource.Pause();
		}
		else
		{
			audioSource.Play();
			isPlaying = true;
		}
	}
}