using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound{

    [Header("AudioSource")]
    public string clipName;

    public AudioClip clip;
    [Range(0f,5f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;

    [Header("ResonanceAudioSource")]
    public bool bypassReverbZone;
    [Range(0f, 1f)]
    public float spatialblend;

    [HideInInspector]
    public AudioSource source;
}
