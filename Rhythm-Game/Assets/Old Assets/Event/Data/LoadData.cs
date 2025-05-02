using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : Event
{
    public override void OnExecute()
    {
        gameManager.dataManager.loadData();
        Terminate();
    }
}
