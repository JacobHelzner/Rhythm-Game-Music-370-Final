using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShutter : MonoBehaviour
{
    public Camera cam;
    public float frameDuration;
    public bool motionless = false;
    float counter = 0;
    bool render = false;
    // Start is called before the first frame update
    void Start()
    {
        cam.enabled = false;
        if (motionless)
        {
            render = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!motionless)
        {
            if (counter > frameDuration)
            {
                cam.Render();
                counter = 0;
            }
            counter += Time.fixedDeltaTime;
        }
        else
        {
            if (render)
            {
                cam.Render();
                render = false;
            }
        }
    }
}
