using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Beat
{
    public List<float> buttonMap;
}

public class Chart : MonoBehaviour
{
    public int BPM;
    public Beat[] beats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
