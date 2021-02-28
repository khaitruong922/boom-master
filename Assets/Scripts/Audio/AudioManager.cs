using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum Sound
{
    Pickup
}
public class AudioManager : MonoBehaviourSingleton<AudioManager>
{

    [System.Serializable]
    private class Audio
    {
        [SerializeField]
        private Sound sound;
        public Sound Sound => sound;
        [SerializeField]
        private AudioClip clip;
        public AudioClip Clip => clip;
        [SerializeField]
        private float volume = 0.5f;
        public float Volume => volume;
        public AudioSource audioSource { get; set; }
    }
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    [SerializeField] private Audio[] audios;
    private Dictionary<Sound, Audio> audioDictionary = new Dictionary<Sound, Audio>();
    protected override void Awake()
    {
        base.Awake();
        foreach (var audio in audios)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audio.Clip;
            audioSource.volume = audio.Volume;
            audioSource.outputAudioMixerGroup = audioMixerGroup;


            audio.audioSource = audioSource;
            audioDictionary[audio.Sound] = audio;
        }
    }
    public void Play(Sound sound)
    {
        audioDictionary[sound].audioSource.Play();
    }
}
