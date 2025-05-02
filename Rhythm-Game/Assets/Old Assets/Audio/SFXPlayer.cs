using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public GameObject soundClipPrefab;
    public void playSound(AudioClip clip, float pitch, float volume)
    {
        GameObject chromaticClip = Instantiate(soundClipPrefab, transform);
        chromaticClip.GetComponent<SFXTimedDestroy>().health = clip.length;
        AudioSource aud = chromaticClip.GetComponent<AudioSource>();
        aud.pitch = pitch;
        aud.PlayOneShot(clip, volume);
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
