using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorState : Event
{
    public Animator target;
    public string parameter;
    public int value;
    public override void OnExecute()
    {
        target.SetInteger(parameter, value);
        Terminate();
    }
}
