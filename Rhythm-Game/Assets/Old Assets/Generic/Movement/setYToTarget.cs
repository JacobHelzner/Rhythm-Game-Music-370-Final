using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setYToTarget : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}
