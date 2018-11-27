using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.resonanceSource = gameObject.AddComponent<ResonanceAudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = 1;
        }
    }

    public void Play(string _clipName) {
        Sound s = Array.Find(sounds, sound => sound.clipName == _clipName);
        if (s == null)
            Debug.LogWarning("The sound " + s.clipName + " does not exist");
        s.source.Play();
    }
    public void Stop(string _clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == _clipName);
        if (s == null)
            Debug.LogWarning("The sound " + s.clipName + " does not exist");
        s.source.Stop();
    }
}
