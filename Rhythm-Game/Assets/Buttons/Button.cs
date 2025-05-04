using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject active;
    public GameObject hit;
    public bool hasSwitched = false;
    public string stickTag = "BlueStick";
    public string wrongStickTag;
    public GameObject hitFX;
    public GameObject wrongFX;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSwitched && other.CompareTag(stickTag))
        {
            Instantiate(hitFX, transform.position + Vector3.up*2, Quaternion.identity);
            other.gameObject.GetComponent<DrumStick>().hitCount++;
            hasSwitched = true;
            active.SetActive(false);
            hit.SetActive(true);
        }
        else if (other.CompareTag(wrongStickTag))
        {
            DrumStick stick = other.gameObject.GetComponent<DrumStick>();
            if (stick.cooldown <= 0f)
            {
                Instantiate(wrongFX, transform.position + Vector3.up * 2, Quaternion.identity);
                other.gameObject.GetComponent<DrumStick>().Cooldown();
            }
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
