using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioMixerGroup ResonanceMixerGroup;
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = 1;

            s.source.bypassReverbZones = s.bypassReverbZone;
            s.source.spatialBlend = s.spatialblend;
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

    public void PlayAtGameObject(string _clipName, GameObject _gameObject) {

        AudioSource goSource;

        if (!_gameObject.GetComponent<ResonanceAudioSource>())
        {
            _gameObject.AddComponent<ResonanceAudioSource>();
        }

        goSource = _gameObject.GetComponent<AudioSource>();

        Sound s = Array.Find(sounds, sound => sound.clipName == _clipName);
        if (s == null)
            Debug.LogWarning("The sound " + s.clipName + " does not exist");

        goSource.clip = s.source.clip;
        goSource.volume = s.source.volume;
        goSource.pitch = s.source.pitch;
        goSource.loop = s.source.loop;
        goSource.spatialBlend = s.source.spatialBlend;

        goSource.bypassReverbZones = s.source.bypassReverbZones;
        goSource.spatialBlend = s.source.spatialBlend;

        goSource.Play();
    }
}
