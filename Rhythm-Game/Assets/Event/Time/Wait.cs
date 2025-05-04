using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Event
{
    public float time;
    float timer;

    public override void OnAwake()
    {
        timer = 0;
    }
    public override void OnExecute()
    {
        timer = time;
    }
    public override void WhileActive()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            Terminate();
        }
    }
}
