using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : MonoBehaviour
{
    public int hitCount = 0;
    public float cooldown = 0;
    int lastHitCount = 0;
    public Metronome metro;

    void Start()
    {
        hitCount = 0;
        lastHitCount = 0;
        cooldown = 0;
    }
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
        if (hitCount > lastHitCount)
        {
            metro.IncreaseScore();
            lastHitCount = hitCount;
        }
    }
}
