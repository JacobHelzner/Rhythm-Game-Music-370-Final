using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBGM : Event
{
    public float targetVolume;
    public float time;
    public bool waitTillDone;
    public override void OnExecute()
    {
        gameManager.audioManager.FadeBGM(time,targetVolume);
        if (!waitTillDone)
        {
            Terminate();
        }
    }

    public override void WhileActive()
    {
        if ((gameManager.audioManager.BGMFading() == false) && waitTillDone)
        {
            Terminate();
        }
    }
}
