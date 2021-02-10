using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClipAtPoint : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 0.5f;
    public void Play()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
    }
}
