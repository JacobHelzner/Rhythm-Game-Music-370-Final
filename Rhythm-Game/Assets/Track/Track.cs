using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Vector2 minBounds = new Vector2(-5f, -5f);
    public Vector2 maxBounds = new Vector2(5f, 5f);
    public float moveDuration = 1.5f; // Duration for moving between targets
    public TrackSegment prefab;
    public Metronome metronome;
    public Transform origin;
    public float beatTimeInSeconds = 0.2f;
    Chart currentChart;
    public Chart initialChart;
    public int currentBeat = 0;

    public float wait_before_audio;

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timeElapsed;

    float prefabSpawnTime;
    public bool playingChart = false;

    public Event endEvent;
    public Event BGMEvent;

    float segmentMoveDuration;

    void PrepareChart(Chart newChart, Event newBGMEvent)
    {
        currentChart = newChart;
        currentChart.BuildBeatsFromMeasures();
        BGMEvent = newBGMEvent;
        currentBeat = 0;
    }

    IEnumerator BeginBGM()
    {
        float time_max = wait_before_audio;
        float time = 0;
        while (time < time_max)
        {
            time += Time.deltaTime;
            yield return null;
        }
        BGMEvent.Execute();
    }

    public void StartPlaying()
    {
        playingChart = true;
        StartCoroutine(BeginBGM());
    }

    public void Initialize(Chart newChart, Event newBGMEvent)
    {
        playingChart = false;
        PrepareChart(newChart, newBGMEvent);
        SetNewTargetPosition();
    }
    void Update()
    {
        MoveTowardsTarget();
    }

    void Start()
    {
        beatTimeInSeconds = 60f / metronome.BPM;
        segmentMoveDuration = metronome.trackMoveDuration;
    }

    void SetNewTargetPosition()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            transform.position.z
        );
        timeElapsed = 0f;
    }

    void MoveTowardsTarget()
    {
        if (timeElapsed < moveDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / moveDuration;
            transform.position = Vector2.Lerp(startPosition, targetPosition, t);
        }
        else
        {
            SetNewTargetPosition();
        }
    }
    public void SpawnTrackSegmentAtPos(Vector3 position)
    {
        TrackSegment newSegment = Instantiate(prefab, position, Quaternion.LookRotation(position - origin.position));
        newSegment.target = origin;
        newSegment.moveDuration = beatTimeInSeconds * 5f;
        if (currentChart == null || playingChart == false)
        {
            newSegment.PrepareSegment(new List<float> { -1f, -1f });
        }
        else
        {
            newSegment.PrepareSegment(currentChart.beats[currentBeat].buttonMap);
            currentBeat++;
            if (currentBeat > (currentChart.beats.Length - 1))
            {
                playingChart = false;
            }
        }
    }

    public void SpawnTrackSegment()
    {
        TrackSegment newSegment = Instantiate(prefab, transform.position, Quaternion.LookRotation(transform.position - origin.position));
        newSegment.target = origin;
        newSegment.moveDuration = beatTimeInSeconds * 5f;
        if (currentChart == null || playingChart == false)
        {
            newSegment.PrepareSegment(new List<float> { -1f, -1f });
        }
        else
        {
            newSegment.PrepareSegment(currentChart.beats[currentBeat].buttonMap);
            currentBeat++;
            if (currentBeat > (currentChart.beats.Length - 1))
            {
                playingChart = false;
            }
        }
    }
}
