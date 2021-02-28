using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClipAtPoint : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 0.5f;
    private Vector3 cameraOffset = new Vector3(0, 0, -10);
    public void Play()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position + cameraOffset, volume);
    }
}
