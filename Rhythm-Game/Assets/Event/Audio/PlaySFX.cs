using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : Event
{
    public AudioClip clip;
    public float pitch;
    public float volume;
    public bool waitTillEnd;
    float counter;

    public override void OnExecute()
    {
        if (gameManager != null)
        {
            gameManager.audioManager.playSFX(clip, pitch, volume);
        }
        if (waitTillEnd)
        {
            counter = clip.length;
        }
        else
        {
            counter = 0;
        }
    }

    public override void WhileActive()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            Terminate();
        }
    }
}
