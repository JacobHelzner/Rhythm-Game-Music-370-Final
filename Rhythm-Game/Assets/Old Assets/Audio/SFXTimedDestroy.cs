using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTimedDestroy : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            health -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
