using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public int BPM;
    public float beatTimeInSeconds;
    public GameObject indicator;
    public Track track;
    float time;
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        beatTimeInSeconds = 60f / (BPM * 4);
        time = beatTimeInSeconds;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            track.SpawnTrackSegment();
            activated = !activated;
            indicator.SetActive(activated);
            float remaining = beatTimeInSeconds + time;
            time = remaining;
            time -= Time.deltaTime;
        }
    }
}
