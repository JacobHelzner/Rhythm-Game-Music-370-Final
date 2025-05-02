using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequenceTail : Event
{
    public EventSequence parent;

    public override void OnExecute()
    {
        parent.Terminate();
    }
}
