using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : Event
{
    public AudioClip clip;
    public float pitch;
    public float volume;

    public override void OnExecute()
    {
        gameManager.audioManager.playBGM(clip, pitch, volume);
        Terminate();
    }
}
