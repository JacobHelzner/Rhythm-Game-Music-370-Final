using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteOnStart : MonoBehaviour
{
    public Event[] events;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Event myEvent in events)
        {
            myEvent.Execute();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
