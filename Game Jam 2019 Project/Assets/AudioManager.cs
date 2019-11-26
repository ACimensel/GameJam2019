using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    // Called before Start
    void Awake()
    {
        if (instance == null)
            instance = this; // if AudioManager doesn't already exist (from previous scenes), set equal to this (created when switching to scene with it)
        else
        {
            Destroy(gameObject); // destroy new AudioManager in scene since another exists
            return; // so no further code is called
        }

        DontDestroyOnLoad(gameObject); // so that the AudioManager persists between scenes. For example if you place one in menu and want it to persist to game

        foreach (Sound s in sounds) {
            // The point of s.source is that the sounds array stores sound clips
            // however they are not created or used, so an AudioSource needs to be
            // added to the gameObject (AudioManager) in the Inspector so that sound plays
            s.source = gameObject.AddComponent<AudioSource>(); 
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Sound can be called from other functions (ie. farting, collisions with the name)
    // To call from another script use:
    // FindObjectOfType<AudioManager>().Play("PlayerDeath");
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
