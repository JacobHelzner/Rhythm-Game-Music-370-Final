using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepareTrackWithChart : Event
{
    public Track track;
    public Chart chart;
    public Event BGMEvent;
    public override void OnExecute()
    {
        track.Initialize(chart, BGMEvent);
        track.StartPlaying();
        Terminate();
    }
}
