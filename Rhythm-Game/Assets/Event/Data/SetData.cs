using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetData : Event
{
    public string key;
    public float value;
    public override void OnExecute()
    {
        gameManager.dataManager.entryLookupTable[key] = value;
        Terminate();
    }
}
