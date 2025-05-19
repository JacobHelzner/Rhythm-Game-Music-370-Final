using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffPulse : Event
{
    public Track track;
    public bool turn_active;
    public override void OnExecute()
    {
        track.doPulse = turn_active;
        Terminate();
    }
}
