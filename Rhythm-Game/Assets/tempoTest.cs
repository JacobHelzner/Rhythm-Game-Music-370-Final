using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempoTest : MonoBehaviour
{
    public GameObject tempoIndicator;
    bool tempoIndicatorActive = false;

    public PlaySFX sound;
    int beat = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrackSegment"))
        {
            if (beat < 3)
            {
                beat += 1;
            }
            else
            {

                sound.Execute();
                tempoIndicatorActive = !tempoIndicatorActive;
                tempoIndicator.SetActive(tempoIndicatorActive);
                beat = 0;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        beat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
