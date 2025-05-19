using DigitalRuby.SimpleLUT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundColor : Event
{
    private IEnumerator LerpValueOverTime(float from, float to, float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            // Calculate the interpolated value
            float currentValue = Mathf.Lerp(from, to, elapsedTime / time);

            lut.Hue = currentValue;

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }
    }
    public SimpleLUT lut;
    public float interval;
    public float target;
    public override void OnExecute()
    {
        StartCoroutine(LerpValueOverTime(lut.Hue, target, interval));
        Terminate();
    }
}