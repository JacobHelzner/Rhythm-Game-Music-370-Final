using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : Event
{
    public override void OnExecute()
    {
        gameManager.dataManager.saveData();
        Terminate();
    }
}
