using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Audio
{
    public string name = "Sound";
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
    public bool loop = false;
    public bool playOnAwake = false;
    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Audio[] sources;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        // Setting up source properties
        foreach(Audio a in sources)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.volume = a.volume;
            a.source.loop = a.loop;
            a.source.clip = a.clip;
            if (a.playOnAwake)
            {
                a.source.Play();
            }
        }
    }

    // Find audio source by name and play it
    public void Play(string name)
    {
        Audio audio = Array.Find(sources, source => source.name == name);
        if (audio == null)
        {
            Debug.LogWarning("Audio clip " + name + " is not found!");
        }
        audio.source.Play();
    }
}
