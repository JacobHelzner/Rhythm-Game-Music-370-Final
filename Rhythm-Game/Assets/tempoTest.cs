using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempoTest : MonoBehaviour
{
    public Metronome metro;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrackSegment"))
        {
            TrackSegment ts = other.GetComponent<TrackSegment>();
            int result = ts.hasMissedButtons();
            if (result == 1)
            {
                metro.missed = true;
            }
            else if (result == 3)
            {
                metro.missed = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
