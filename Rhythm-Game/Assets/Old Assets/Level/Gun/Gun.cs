using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public PlaySFX shootSound;
    public Bullet myBullet;
    public float cooldown;
    float cooldownTimer;
    GameManager gameManager;
    LevelManager levelManager;

    void Shoot()
    {
        shootSound.Execute();
        Bullet newBullet = Instantiate(myBullet, transform.position, transform.rotation);
        newBullet.levelManager = levelManager;
        cooldownTimer = cooldown;
    }

    public void Trigger()
    {
        if (cooldownTimer == 0f)
        {
            Shoot();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        levelManager = gameManager.levelManager;
        cooldownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            cooldownTimer = 0;
        }
    }
}
