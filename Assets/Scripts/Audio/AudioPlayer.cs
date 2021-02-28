using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private Sound sound;
    private AudioManager audioManager;
    private void Start() {
        audioManager = AudioManager.Instance;
    }
    public void Play()
    {   
        audioManager.Play(sound);
    }
    
}

