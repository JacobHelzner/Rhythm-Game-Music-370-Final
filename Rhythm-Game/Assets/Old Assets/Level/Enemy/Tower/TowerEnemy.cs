using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : Enemy
{
    public Gun myGun;

    public float startDelay;

    float startDelayTimer;

    Transform playerTransform;

    public override void onStart()
    {
        startDelayTimer = 0;
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public override void onEnter()
    {
        startDelayTimer = startDelay;
    }
    public override void Behavior()
    {
        transform.LookAt(playerTransform);
        if (startDelayTimer > 0)
        {
            startDelayTimer -= Time.deltaTime;
        }
        else
        {
            myGun.Trigger();
        }
    }
}
