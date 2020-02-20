using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class SlenderWarning : MonoBehaviour {
    // [Header("<SlenderWarning> Script Settings")]
    // public PageCounter pagecounter; //pagecounter script
    // public GameObject PageCounter; //PageCounter gameobject
    
    [Header("Glitch/Static Effect Settings")]
    public AudioClip StaticSFX; //the static noise
	// public Camera PlayerCam; //Player's camera
	// public GlitchEffect glitch; //Glitch effect
 	public GameObject StaticSFXContainer; //the gameobject which contains the audiosource required
	AudioSource StaticSFXSource; //audiosource required

    [Header("Text Settings")]
    public Text Warning;
    private float duration = 2f;
    private float timeStarted;

    void Start() {
        StaticSFXSource = StaticSFXContainer.GetComponent<AudioSource>(); // PageSFX is the audiosource attached to PageSFXContainer gameobject
        // pagecounter = PageCounter.GetComponent<PageCounter>(); // pagecounter is the script <PageCounter> attached to it
        Warning.enabled = false;
        Warning.text = "HE'S HERE";
        // glitch = PlayerCam.GetComponent<GlitchEffect>(); // glitch is the script <GlitchEffect> attached to PlayerCam
    }

    public void triggerWarning() {
        Debug.Log("Triggering warning");
        StaticSFXSource.PlayOneShot(StaticSFX);
        Warning.enabled = true;
        timeStarted = Time.time;
    }

    void Update() {
        if (Warning.enabled && (Time.time >= (timeStarted + duration))) {
            Warning.enabled = false;
        }
    }
}