using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryObjects : MonoBehaviour
{
    public GameObject deadman1;
    public GameObject deadman_hanging1;
    public GameObject deadman2;
    public GameObject deadman_clone2;
    public GameObject deadman3;
    public GameObject deadman_hanging3;
    public GameObject deadman4;
    public GameObject deadman_clone4;
    public GameObject deadman5;
    public GameObject deadman_hanging5;
    public GameObject deadman6;
    public GameObject deadman_clone6;
    public GameObject deadman_hanging6;
    public GameObject deadman7;
    public GameObject deadman_hanging7;
    public GameObject deadman8;
    public GameObject deadman_hanging8;

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

    public void appear(int pageNum)
    {
        Debug.Log("Making scary objects appear...");
        StaticSFXSource.Play();
        Debug.Log("glitch effects");
        glitch.intensity = 1;
        glitch.flipIntensity = 1;
        glitch.colorIntensity = 0.3f;
        switch (pageNum)
        {
            case 1:
                deadman1.GetComponent<Renderer>().enabled = true;
                deadman_hanging1.SetActive(true);
                break;
            case 2:
                deadman2.GetComponent<Renderer>().enabled = true;
                deadman_clone2.GetComponent<Renderer>().enabled = true;
                break;
            case 3:
                deadman3.GetComponent<Renderer>().enabled = true;
                deadman_hanging3.SetActive(true);
                break;
            case 4:
                deadman4.GetComponent<Renderer>().enabled = true;
                deadman_clone4.GetComponent<Renderer>().enabled = true;
                break;
            case 5:
                deadman5.GetComponent<Renderer>().enabled = true;
                deadman_hanging5.SetActive(true);
                break;
            case 6:
                deadman6.GetComponent<Renderer>().enabled = true;
                deadman_clone6.GetComponent<Renderer>().enabled = true;
                deadman_hanging6.SetActive(true);
                break;
            case 7:
                deadman7.GetComponent<Renderer>().enabled = true;
                deadman_hanging7.SetActive(true);
                break;
            case 8:
                deadman8.GetComponent<Renderer>().enabled = true;
                deadman_hanging8.SetActive(true);
                break;
            default:
                Debug.Log("Invalid page number");
                break;
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        Debug.Log("waiting " + Time.time);
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("finished " + Time.time);
        StaticSFXSource.Stop();
        glitch.intensity = 0;
        glitch.flipIntensity = 0;
        glitch.colorIntensity = 0;
        scarySound.Play();
    }
}
