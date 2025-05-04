using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTestJunction : Event
{
    public Event[] options;
    public dataEntry[] states;

    public override void OnExecute()
    {
        if (options.Length != states.Length)
        {
            Debug.Log("ERROR: options and states length mismatch in DataTestJunction " + name);
        }
        else
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (states[i].value == gameManager.dataManager.getDataValue(states[i].key))
                {
                    options[i].Execute();
                }
            }
        }
        Terminate();
    }
}
