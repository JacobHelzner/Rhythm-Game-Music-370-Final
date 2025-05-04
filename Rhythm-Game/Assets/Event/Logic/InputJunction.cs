using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputJunction : Event
{
    public Event[] options;
    public KeyCode[] keys;

    public override void OnExecute()
    {
        if (options.Length != keys.Length)
        {
            Debug.Log("ERROR: options length != keys length in Input Junction " + name);
            Terminate();
        }
    }
    public override void WhileActive()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    next = options[i];
                    Terminate();
                }
            }
        }
    }
}
