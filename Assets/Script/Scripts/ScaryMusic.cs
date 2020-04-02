using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryMusic : MonoBehaviour
{
    public GameObject GhostContainer;
    public GameObject BreathingContainer;
    AudioSource ghostSource;
    AudioSource breathingSource;
    public AudioClip breathing;
    public AudioClip ghost;

    // Start is called before the first frame update
    void Start()
    {
        ghostSource = GhostContainer.GetComponent<AudioSource>();
        breathingSource = BreathingContainer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGhostClip(float seconds)
    {
        StartCoroutine(PlayAfterSeconds(ghostSource, ghost, seconds));
    }

    public void PlayBreathingClip(float seconds)
    {
        StartCoroutine(PlayAfterSeconds(breathingSource, breathing, seconds));
    }

    IEnumerator PlayAfterSeconds(AudioSource source, AudioClip clip, float seconds)
    {
        Debug.Log("start " + Time.time);
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("finish " + Time.time);
        source.PlayOneShot(clip, 1.0f);
    }
}
