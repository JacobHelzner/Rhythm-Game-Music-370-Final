using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public int BPM;
    public Track track;
    public float trackMoveDuration;
    public Event startEventSequence;
    public bool CheckFramerateDependency;
    public TextMesh text;

    public GameObject debug_indicator;
    public float score;
    float beatTimeInSeconds;
    float time;
    bool activated;
    public void IncreaseScore()
    {
        score++;
    }
    // Start is called before the first frame update
    void Start()
    {
        beatTimeInSeconds = 60f / (BPM * 4);
        time = beatTimeInSeconds;
        activated = false;
        startEventSequence.Execute();
        if (CheckFramerateDependency)
        {
            Application.targetFrameRate = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int trueScore = (int)(score / 2);
        text.text = $"{trueScore}";
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            track.SpawnTrackSegment();
            activated = !activated;
            debug_indicator.SetActive(activated);
            float remaining = beatTimeInSeconds + time;
            time = remaining;
            time -= Time.deltaTime;
        }
    }
}
