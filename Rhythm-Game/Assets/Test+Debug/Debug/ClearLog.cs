using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLog : Event
{
    public override void OnExecute()
    {
        Debug.ClearDeveloperConsole();
        Terminate();
    }
}
