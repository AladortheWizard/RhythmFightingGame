using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioFadeOut : MonoBehaviour
{
    public AudioSource audio;

    private void Start()
    {
    }
    public void Fade()
    {
        StartCoroutine(FadeOut(audio, 1));
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

}