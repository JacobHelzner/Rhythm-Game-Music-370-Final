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
    public Transform origin;
    public float beatTimeInSeconds = 0.2f;
    Chart currentChart;
    public Chart initialChart;
    public int currentBeat = 0;

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timeElapsed;

    void PrepareChart(Chart newChart)
    {
        currentChart = newChart;
        beatTimeInSeconds = 60f / (currentChart.BPM * 4f);
        currentBeat = 0;
    }

    void Start()
    {
        PrepareChart(initialChart);
        StartCoroutine(SpawnPrefabRoutine());
        SetNewTargetPosition();
    }

    void Update()
    {
        MoveTowardsTarget();
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

    IEnumerator SpawnPrefabRoutine()
    {
        while (true)
        {
            TrackSegment newSegment = Instantiate(prefab, transform.position, Quaternion.LookRotation(transform.position - origin.position));
            newSegment.target = origin;
            newSegment.moveDuration = (2f / 0.1f) * beatTimeInSeconds;
            if (currentChart == null)
            {
                newSegment.PrepareSegment(new List<float> { -1f, -1f });
            }
            else
            {
                newSegment.PrepareSegment(currentChart.beats[currentBeat].buttonMap);
                currentBeat++;
                if (currentBeat > (currentChart.beats.Length - 1))
                {
                    currentBeat = 0;
                }
            }
            yield return new WaitForSeconds(beatTimeInSeconds);
        }
    }
}
