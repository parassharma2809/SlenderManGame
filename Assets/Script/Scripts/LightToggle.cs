//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.
//To give that buggy flashlight feel in a slender forest, I have included 2 random numbers which will be updated every frame.. so if the player presses 'f', he/she has to do it twice or thrice to on/off the flashlight. You can chnage it by removing the random numbers.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightToggle : MonoBehaviour {

	[Header("Flashlight")]
	private Light flashlight; // light component
	
	[Header("Random Number")]
	float random1; // random number
	float random2; // random number
	
    [Header("Flashlight Battery Settings")]
    public GameObject batterySlider;
    public float battery = 100;
    public float batteryMax = 100;
    public float removeBatteryValue = 0.05f;
    public float secondToRemoveBaterry = 5f;

	[Header("Torch On/Off SFX Settings")]
 	public GameObject TorchOnOffSFXContainer; //the gameobject which contains the audiosource required
	AudioSource TorchOnOffSFX; //on/off sfx for torch

	void Start(){
		battery = batteryMax;
		
		flashlight = GetComponent<Light>();
		
		TorchOnOffSFX = TorchOnOffSFXContainer.GetComponent<AudioSource>(); // TorchOnOffSFX is the audiosource attached to TorchOnOffSFXContainer gameobject
		
        // set initial battery values
        batterySlider.GetComponent<Slider>().maxValue = batteryMax;
        batterySlider.GetComponent<Slider>().value = batteryMax;
		
        // start consume flashlight battery
        StartCoroutine(RemoveBaterryCharge(removeBatteryValue, secondToRemoveBaterry));
	}

	void LateUpdate(){
		// update baterry slider
        batterySlider.GetComponent<Slider>().value = battery;
		
		random1 = Random.Range (0f, 100f); // get random number between 0 and 100
		random2 = Random.Range (0f, 100f); // get random number between 0 and 100
		
		if (Input.GetKeyDown(KeyCode.F)) // if f is pressed
		{
			if (random1 >= random2)  // if random number is bigger than light range
			{
				flashlight.enabled = false; // disable the light component	
				TorchOnOffSFX.Play(); //Play on/off SFX
			}
			else // or else
			{
				flashlight.enabled = true; // enable the light component
				TorchOnOffSFX.Play(); //Play on/off SFX
			}
		}
		
		//battery part
        // if battery is low 50%
        if (battery / batteryMax * 100 <= 50)
        {
            Debug.Log("Flashlight is running out of battery.");
            flashlight.intensity = 2.85f;
        }

        // if battery is low 25%
        if (battery / batteryMax * 100 <= 25)
        {
            Debug.Log("Flashlight is almost without battery.");
            flashlight.intensity = 2.0f;
        }

        // if battery is low 10%
        if (battery / batteryMax * 100 <= 10)
        {
            Debug.Log("You will be out of light.");
            flashlight.intensity = 1.35f;           
        }

        // if battery out
        if (battery / batteryMax * 100 <= 0)
        {
            battery = 0.00f;
            Debug.Log("The flashlight battery is out and you are out of the light.");
            flashlight.intensity = 0.0f;
        }
	}
	
    public IEnumerator RemoveBaterryCharge(float value, float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            Debug.Log("Removing baterry value: " + value);
            flashlight.intensity = 0.0f;

            if (battery > 0)
                battery -= value;
            else
                Debug.Log("The flashlight battery is out");
        }
    }
}
