using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequence : Event
{
    public Event[] events;


    public override void OnAwake()
    {
        for (int i = 0; i < events.Length - 1; i++)
        {
            events[i].next = events[i + 1];
        }
        GameObject tail = new GameObject("Tail");
        tail.transform.parent = this.transform;
        tail.AddComponent<EventSequenceTail>();
        EventSequenceTail tailComponent = tail.GetComponent<EventSequenceTail>();
        tailComponent.parent = this;
        events[events.Length - 1].next = tailComponent;
    }

    public override void OnExecute()
    {
        events[0].Execute();
    }
}
