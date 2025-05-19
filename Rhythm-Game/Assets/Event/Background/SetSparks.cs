
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSparks : Event
{
    public Track track;
    public bool doOrNot;
    public override void OnExecute()
    {
        track.doSparks = doOrNot;
        Terminate();
    }
}