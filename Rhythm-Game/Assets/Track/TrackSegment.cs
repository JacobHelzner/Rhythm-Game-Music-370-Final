using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    public GameObject red_1;
    public GameObject blue_1;
    public Transform root_1;
    public Transform root_2;
    public List<GameObject> buttons;
    public void SetButtons(List<float> offsets)
    {
        for (int i = 0; i < offsets.Count; i++)
        {
            if (offsets[i] != -1f)
            {
                buttons[i].SetActive(true);
                if (i < 2)
                {
                    buttons[i].transform.localPosition = root_1.transform.localPosition;
                }
                else
                {
                    buttons[i].transform.localPosition = root_2.transform.localPosition;
                }
                buttons[i].transform.localPosition += new Vector3(offsets[i], 0, 0);
                float randomYRotation = Random.Range(0f, 360f);
                buttons[i].transform.localRotation = Quaternion.Euler(buttons[i].transform.localRotation.eulerAngles.x, randomYRotation, buttons[i].transform.localRotation.eulerAngles.z);
            }
        }
    }

    public Transform target;
    public float moveDuration = 1f; // Duration to reach target
    public float movePastDuration = 1.5f;
    [SerializeField]
    public Vector3 lastVelocity;

    IEnumerator MovePast()
    {
        yield return StartCoroutine(HoneInOnTarget());
        float time2 = 0;
        while (time2 < movePastDuration) {
            time2 += Time.deltaTime;
            transform.position += lastVelocity * Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
    IEnumerator HoneInOnTarget()
    {
        Vector3 P1 = transform.position;
        Vector3 V1 = transform.rotation.eulerAngles;
        Vector3 P2 = target.position;
        Vector3 V2 = target.rotation.eulerAngles;
        float time = 0f;

        while (time / moveDuration < 0.8f)
        {
            time += Time.deltaTime;
            float t = time / moveDuration;
            Vector3 next_position = Mathf.Pow(1 - t, 3f) * P1 + 3 * Mathf.Pow(1 - t, 3f) * (P1 - (1 / 3) * V1) * t + 3 * (1 - t) * Mathf.Pow(t, 2f) * (P2 + (1 / 3) * V2) + Mathf.Pow(t, 3f) * P2;
            transform.LookAt(next_position);
            lastVelocity = (next_position - transform.position) / Time.deltaTime;
            transform.position = next_position;
            yield return null; // Wait for next frame
        }
    }

    public void PrepareSegment(List<float> offsets)
    {
        SetButtons(offsets);
        StartCoroutine(MovePast());
    }


    // Start is called before the first frame update
    void Awake()
    {
        buttons.Add(red_1);
        buttons.Add(blue_1);
    }
}
