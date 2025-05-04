using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : Event
{
    public string sceneName;
    public override void OnExecute()
    {
        SceneManager.LoadScene(sceneName);
        Terminate();
    }
}
