using UnityEngine.Audio;
using UnityEngine;

//This is a custom Sound class to be used with the AudioManager
//where AudioManager will contain an array of Sounds, each of
//which will have their own settings created below

[System.Serializable] //Need to serialize to be able to use custom class in AudioManager
public class Sound
{
    public string name;
    public AudioClip clip; // audio clip to drop in on the Inspector

    [Range(0f, 1f)] // adds a slider to the Inspector
    public float volume; // volume slider
    [Range(0f, 1f)]
    public float pitch; // pitch slider

    public bool loop;

    [HideInInspector] // We don't want to show this in Inspector, it's a value we populate automaticalli in awake method of AudioManager
    public AudioSource source;
}
