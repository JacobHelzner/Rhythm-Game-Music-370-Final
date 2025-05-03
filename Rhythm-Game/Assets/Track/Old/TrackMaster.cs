using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMaster : MonoBehaviour
{
    public GameObject LeftTurn;
    public GameObject RightTurn;
    public GameObject Straight;
    public GameObject InitialTrack;

    public float timeInterval = 2f;  // Default time interval

    private Vector3 startPositionRight;
    private Quaternion startRotationRight;
    private Vector3 startPositionLeft;
    private Quaternion startRotationLeft;

    public bool justTurned = true;


    IEnumerator MoveStraight(GameObject obj, float interval)
    {
        // Move object 139.5515 units in x direction
        Vector3 endPosition = startPositionLeft + new Vector3(0, 0, 139.5515f);
        yield return StartCoroutine(InterpolatePosition(obj, endPosition, startPositionLeft, interval));

        Vector3 endPosition2 = startPositionLeft - new Vector3(0, 0, 139.5515f);
        justTurned = false;
        MakeNextMovement();

        yield return StartCoroutine(InterpolatePosition(obj, startPositionLeft, endPosition2, interval));

        //do something here
    }

    IEnumerator MoveAndRotateRight(GameObject obj, float interval)
    {
        RightTurn.transform.rotation = startRotationRight;
        // Move object 139.5515 units in x direction
        Vector3 endPosition = startPositionRight + new Vector3(0, 0, 139.5515f);
        yield return StartCoroutine(InterpolatePosition(obj, endPosition, startPositionRight, interval));

        // Reset interval and start rotation interpolation (0 to 90 degrees)
        yield return StartCoroutine(InterpolateRotation(obj, startRotationRight, Quaternion.Euler(0, -180, 0), interval));

        Vector3 endPosition2 = startPositionRight - new Vector3(0, 0, 139.5515f);
        justTurned = true;
        InitialTrack.SetActive(false);
        MakeNextMovement();

        yield return StartCoroutine(InterpolatePosition(obj, startPositionRight, endPosition2, interval));

        //do something here
    }

    IEnumerator MoveAndRotateLeft(GameObject obj, float interval)
    {
        LeftTurn.transform.rotation = startRotationLeft;
        // Move object 139.5515 units in x direction
        Vector3 endPosition = startPositionLeft + new Vector3(0, 0, 139.5515f);
        yield return StartCoroutine(InterpolatePosition(obj, endPosition, startPositionLeft, interval));

        // Reset interval and start rotation interpolation (0 to 90 degrees)
        yield return StartCoroutine(InterpolateRotation(obj, startRotationLeft, Quaternion.Euler(0, 90, 0), interval));

        Vector3 endPosition2 = startPositionLeft - new Vector3(0, 0, 139.5515f);
        justTurned = true;
        InitialTrack.SetActive(false);
        MakeNextMovement();

        yield return StartCoroutine(InterpolatePosition(obj, startPositionLeft, endPosition2, interval));

        //do something here
    }

    IEnumerator InterpolatePosition(GameObject obj, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = to;
    }

    IEnumerator InterpolateRotation(GameObject obj, Quaternion initialRotation, Quaternion targetRotation, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        obj.transform.rotation = targetRotation;
    }

    void TurnRight()
    {
        StartCoroutine(MoveAndRotateRight(RightTurn, timeInterval));
    }

    void TurnLeft()
    {
        StartCoroutine(MoveAndRotateLeft(LeftTurn, timeInterval));
    }

    void GoStraight()
    {
        StartCoroutine(MoveStraight(Straight, timeInterval));
    }


    void MakeNextMovement()
    {
        if (justTurned)
        {
            GoStraight();
        }
        else
        {
            int choice = Random.Range(0, 2);
            if (choice == 0)
            {
                TurnLeft();
            }
            else if (choice == 1)
            {
                TurnRight();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Movement and rotation completed!");
        startPositionRight = RightTurn.transform.position;
        startRotationRight = RightTurn.transform.rotation;
        startPositionLeft = LeftTurn.transform.position;
        startRotationLeft = LeftTurn.transform.rotation;

        LeftTurn.transform.position = startPositionLeft - new Vector3(0, 0, 500f);
        RightTurn.transform.position = startPositionRight - new Vector3(0, 0, 500f);
        justTurned = true;
        InitialTrack.SetActive(true);
        MakeNextMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
