using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMessage : Event
{
    public string message;
    public override void OnExecute()
    {
        Debug.Log(message);
        Terminate();
    }
}
