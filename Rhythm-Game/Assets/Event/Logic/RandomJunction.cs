using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJunction : Event
{
    public Event[] options;
    public override void OnExecute()
    {
        int choice = Random.Range(0, options.Length);
        next = options[choice];
        Terminate();
    }
}
