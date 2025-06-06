using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetNoRot : MonoBehaviour
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
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
    }
}
