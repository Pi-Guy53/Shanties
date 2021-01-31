using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicTest : MonoBehaviour
{
    private AudioSource aud;
    public Text pitchTxt;

    private void Start()
    {
        aud = GetComponent<AudioSource>(); 
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);

        Invoke("Play", 10f);
    }

    private void Play()
    {
        aud.Play();
        pitchTxt.text = "" + aud.pitch;
    }
}
