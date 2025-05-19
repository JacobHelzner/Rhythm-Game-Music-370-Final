using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Measure
{
    public Beat[] beats;
    public float repeat_times;
}

[System.Serializable]
public class Beat
{
    public List<float> buttonMap;
    public Event beatEvent;
}

public class Chart : MonoBehaviour
{
    public int BPM;
    public Beat[] beats;
    public Measure[] measures;

    public void BuildBeatsFromMeasures()
    {
        foreach (Measure meas in measures)
        {
            for (int i = 0; i < meas.repeat_times; i++)
            {
                beats = beats.Concat(meas.beats).ToArray();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
