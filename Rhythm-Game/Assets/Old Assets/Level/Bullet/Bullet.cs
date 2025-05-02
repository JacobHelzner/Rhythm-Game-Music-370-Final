using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LevelManager levelManager;
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ScreenRegion"))
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void Behavior()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelManager.paused)
        {
            Behavior();
        }
    }
}
