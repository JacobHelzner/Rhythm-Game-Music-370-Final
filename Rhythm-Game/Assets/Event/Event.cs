using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;
    public Event next;
    bool active;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        active = false;
        OnAwake();
    }
    public void Execute()
    {
        active = true;
        OnExecute();
    }
    // Start is called before the first frame update
    public void Terminate()
    {
        active = false;
        OnTerminate();
        if (next != null)
        {
            next.Execute();
        }
    }

    public virtual void OnAwake()
    {

    }

    public virtual void OnExecute()
    {

    }

    public virtual void OnTerminate()
    {

    }

    public virtual void WhileActive()
    {

    }

    public virtual void WhileActiveFixed()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            WhileActive();
        }
    }

    void FixedUpdate()
    {
        if (active)
        {
            WhileActiveFixed();
        }
    }
}
