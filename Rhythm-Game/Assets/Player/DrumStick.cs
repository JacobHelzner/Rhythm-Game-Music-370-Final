using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : MonoBehaviour
{
    public int hitCount = 0;
    public float cooldown = 0;
    public void Cooldown()
    {
        cooldown = 0.15f;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
