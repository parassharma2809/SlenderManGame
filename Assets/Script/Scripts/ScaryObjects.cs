using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryObjects : MonoBehaviour
{
    public GameObject deadbodies;
    public Camera PlayerCam; //Player's camera
    public GlitchEffect glitch; //Glitch effect
    public GameObject StaticSFXContainer; //the gameobject which contains the audiosource required
    AudioSource StaticSFXSource; //audiosource required

    AudioSource scarySound;
    // Start is called before the first frame update
    void Start()
    {
        scarySound = this.gameObject.GetComponent<AudioSource>();
        StaticSFXSource = StaticSFXContainer.GetComponent<AudioSource>(); // PageSFX is the audiosource attached to PageSFXContainer gameobject
        glitch = PlayerCam.GetComponent<GlitchEffect>(); // glitch is the script <GlitchEffect> attached to PlayerCam
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void appear()
    {
        // Debug.Log("Making scary objects appear...");
        StaticSFXSource.Play();
        // Debug.Log("glitch effects");
        glitch.intensity = 1;
        glitch.flipIntensity = 1;
        glitch.colorIntensity = 0.3f;
        deadbodies.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        // Debug.Log("waiting " + Time.time);
        yield return new WaitForSecondsRealtime(2.0f);
        // Debug.Log("finished " + Time.time);
        StaticSFXSource.Stop();
        glitch.intensity = 0;
        glitch.flipIntensity = 0;
        glitch.colorIntensity = 0;
        scarySound.Play();
    }
}
