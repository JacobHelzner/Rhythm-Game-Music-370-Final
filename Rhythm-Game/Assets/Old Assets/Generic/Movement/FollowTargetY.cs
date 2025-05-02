using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetY : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3( transform.localPosition.x, target.localPosition.y, transform.localPosition.z), followSpeed * Time.deltaTime);
    }
}
