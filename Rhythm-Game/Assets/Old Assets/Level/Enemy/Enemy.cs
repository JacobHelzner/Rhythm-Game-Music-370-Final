using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool active;
    GameManager gameManager;
    LevelManager levelManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScreenRegion"))
        {
            active = true;
            onEnter();
        }
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ScreenRegion"))
        {
            active = false;
            onExit();
        }
    }

    public virtual void Behavior()
    {

    }

    public virtual void onStart()
    {

    }

    public virtual void onEnter()
    {

    }

    public virtual void onExit()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        levelManager = gameManager.levelManager;
        active = false;
        onStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !levelManager.paused)
        {
            Behavior();
        }
    }
}
