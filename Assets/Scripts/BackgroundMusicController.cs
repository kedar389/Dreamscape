using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
	private AudioSource audioSource;
	private bool isPlaying = false;

	void Start()
	{
		GameObject audioSourceGameObject = new GameObject("AudioSource");
		audioSourceGameObject.transform.SetParent(transform);

		// Add the AudioSource component to the new GameObject
		audioSource = audioSourceGameObject.AddComponent<AudioSource>();

		// Configure the AudioSource component (optional)
		audioSource.playOnAwake = false;
		audioSource.loop = true;
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
			audioSource.Play();
			isPlaying = true;
		}
	}

	public void onOff()
	{
		if (isPlaying) { 
			isPlaying = false;
			audioSource.Stop();
		}
		else
		{
			audioSource.Play();
			isPlaying = true;
		}
	}
}