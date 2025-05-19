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
    public int score;
    float beatTimeInSeconds;
    float time;
    bool activated;
    public bool missed;
    public Animator scoreAnimator;
    public int streak;

    public GameObject streakFX;

    int scoreIncrement;

    private IEnumerator ResetScoreAnimator()
    {
        // Wait for 2 frames
        yield return null; // Wait for 1 frame
        yield return null; // Wait for another frame

        // Execute your function
        scoreAnimator.SetBool("triggered", false);
    }
    public void IncreaseScore()
    {
        scoreAnimator.SetBool("triggered", true);
        score += scoreIncrement;
        if (!missed)
        {
            streak++;
        }
        StartCoroutine(ResetScoreAnimator());
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreIncrement = 1;
        missed = false;
        streak = 0;
        beatTimeInSeconds = 60f / (BPM * 4);
        time = beatTimeInSeconds;
        activated = false;
        startEventSequence.Execute();
        if (CheckFramerateDependency)
        {
            Application.targetFrameRate = 20;
        }
    }

    void HandleStreak()
    {
        if (missed)
        {
            streak = 0;
        }
        if (streak > 15)
        {
            streakFX.SetActive(true);
            scoreIncrement = 2;
        }
        else
        {
            streakFX.SetActive(false);
            scoreIncrement = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleStreak();
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
