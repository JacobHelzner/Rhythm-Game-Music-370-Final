using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepareTrackWithChart : Event
{
    public Track track;
    public Chart chart;
    public override void OnExecute()
    {
        track.Initialize(chart);
        Terminate();
    }
}
