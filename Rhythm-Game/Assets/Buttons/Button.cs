using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject active;
    public GameObject hit;
    public bool hasSwitched = false;
    public string stickTag = "BlueStick";

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSwitched && other.CompareTag(stickTag))
        {
            other.gameObject.GetComponent<DrumStick>().hitCount++;
            hasSwitched = true;
            active.SetActive(false);
            hit.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
