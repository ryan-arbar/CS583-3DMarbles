using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public AudioSource audioSource;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (audioSource != null)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}


	void Start()
	{
		PlaySound("Theme");
	}


	public void PlaySound(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Play() Sound: " + sound + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("StopPlaying() Sound: " + sound + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Stop();
    }

	public void SetVolume(string sound, float volume)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s != null)
		{
			s.source.volume = volume;
		}
		else
		{
			Debug.LogWarning("SetVolume() Sound: " + sound + " not found!");
		}
	}

	public void SetPitch(string sound, float pitch)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s != null)
		{
			s.source.pitch = pitch;
		}
		else
		{
			Debug.LogWarning("SetPitch() Sound: " + sound + " not found!");
		}
	}


}
