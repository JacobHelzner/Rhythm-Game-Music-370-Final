using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    [SerializeField]
    public Transform root; // External root transform
    public GameObject roadPrefab; // Prefab for instantiating new road sections
    public float moveDuration = 2f; // Time for each segment to align

    private Transform[] roadSegments;
    private int currentSegmentIndex = 0;
    private bool isMoving = false;
    private GameObject currentRoad = null;

    void Start()
    {
        currentRoad = Instantiate(roadPrefab, root.position, root.rotation);
        roadSegments = currentRoad.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveNextSegment());
        }
    }

    private IEnumerator MoveNextSegment()
    {
        isMoving = true;

        Transform currentSegment = roadSegments[0];

        Vector3 startPosition = currentSegment.position;
        Quaternion startRotation = currentSegment.rotation;
        Vector3 endPosition = root.position;
        Quaternion endRotation = root.rotation;


        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / moveDuration;

            // Bezier interpolation between start and end positions
            currentRoad.transform.position = Vector3.Slerp(startPosition, endPosition, t);
            currentRoad.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            yield return null;
        }

        currentRoad = Instantiate(roadPrefab);
        roadSegments = currentRoad.GetComponentsInChildren<Transform>();

        isMoving = false;
    }
}