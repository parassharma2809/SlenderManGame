using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class SlenderWarning : MonoBehaviour
{

    [Header("Glitch/Static Effect Settings")]
    public AudioClip WarningSFX; //the static noise
    public Camera PlayerCam;
    public GlitchEffect glitch; //Glitch effect
    public GameObject WarningFXContainer; //the gameobject which contains the audiosource required
    AudioSource WarningSFXSource; //audiosource required

    [Header("Text Settings")]
    Text Warning;
    private float duration = 2f;
    private float timeStarted;

    void Start()
    {
        // Debug.Log("started in slenderwarning");
        WarningSFXSource = WarningFXContainer.GetComponent<AudioSource>();
        glitch = PlayerCam.GetComponent<GlitchEffect>();
        Warning = this.gameObject.GetComponent<Text>();
        Warning.enabled = false;
    }

    public void triggerWarning()
    {
        // Debug.Log("Triggering warning");
        Warning.enabled = true;
        WarningSFXSource.Play();
        glitch.intensity = 1;
        glitch.flipIntensity = 1;
        glitch.colorIntensity = 0.3f;
        timeStarted = Time.time;
    }

    void Update()
    {
        if (Warning.enabled && (Time.time >= timeStarted + duration))
        {
            // Debug.Log("Stop showing the warning message!!");
            glitch.intensity = 0;
            glitch.flipIntensity = 0;
            glitch.colorIntensity = 0;
            Warning.enabled = false;
        }
    }
}