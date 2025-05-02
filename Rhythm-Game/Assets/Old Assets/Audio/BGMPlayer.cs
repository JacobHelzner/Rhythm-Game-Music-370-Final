using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public GameObject BGMPrefab;
    GameObject playerInstance;
    AudioSource aud;

    float fadeTime;
    float currentFadeTime;
    float fadeStartVolume;
    float fadeTargetVolume;

    public bool fading;

    int fadeDirection;

    public void playBGM(AudioClip clip, float pitch, float volume)
    {
        aud.Stop();
        if (clip != null)
        {
            aud.pitch = pitch;
            aud.volume = volume;
            aud.clip = clip;
            aud.Play();
        }
    }

    public void Fade(float time, float targetVolume)
    {
        fadeTargetVolume = targetVolume;
        fadeStartVolume = aud.volume;
        fadeTime = time;
        currentFadeTime = 0;
        fading = true;
    }

    public void Initialize()
    {
        fading = false;
        playerInstance = Instantiate(BGMPrefab, transform);
        aud = playerInstance.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            currentFadeTime += Time.deltaTime;
            aud.volume = Mathf.Lerp(fadeStartVolume, fadeTargetVolume, currentFadeTime / fadeTime);
            if (currentFadeTime >= fadeTime)
            {
                fading = false;
            }
        }
    }
}
