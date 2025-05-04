using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public BGMPlayer BGMPlayerPrefab;
    public SFXPlayer SFXPlayerPrefab;
    BGMPlayer BGM;
    SFXPlayer SFX;
    // Start is called before the first frame update
    public void Initialize()
    {
        BGM = Instantiate(BGMPlayerPrefab, this.transform, false);
        BGM.Initialize();
        SFX = Instantiate(SFXPlayerPrefab, this.transform, false);
    }

    // Plays an unlooped audio clip with pitch and volume.
    public void playSFX(AudioClip clip, float pitch, float volume)
    {
        SFX.playSound(clip, pitch, volume);
    }

    // Plays a looped audio clip with pitch and volume. Passing a null 
    // AudioClip will stop the current clip.
    public void playBGM(AudioClip clip, float pitch, float volume)
    {
        BGM.playBGM(clip, pitch, volume);
    }

    // Transitions between the current volume and given target volume
    // over the course of a given time. time = 0 effectively instantly
    // sets BGM volume.
    public void FadeBGM(float time, float targetVolume)
    {
        BGM.Fade(time, targetVolume);
    }

    // Whether or not the BGM is currently transitioning between
    // volumes.
    public bool BGMFading()
    {
        return BGM.fading;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
