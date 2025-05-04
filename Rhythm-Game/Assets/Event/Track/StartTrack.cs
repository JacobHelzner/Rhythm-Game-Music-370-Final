using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTrack : Event
{
    public Track track;
    public override void OnExecute()
    {
        track.StartPlaying();
        Terminate();
    }
}
