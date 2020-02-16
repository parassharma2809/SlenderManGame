//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.
//Simple script to zoom in and out.

using UnityEngine;
using System.Collections;

public class CameraZoom: MonoBehaviour {

	[Header("Zoom Settings")]
	public int zoom = 40; // Zoom FOV
	public int normal = 60; // Normal FOV
	public float smooth = 5; // Transition speed
	private bool isZoomed = false; // boolean to determine if the camera isZoomed or not.
	
	[Header("Zoom SFX Settings")]
 	public GameObject ZoomSFXContainer; //the gameobject which contains the audiosource required
	AudioSource ZoomSFXSource; //audiosource required
	
	void Start()
	{
		ZoomSFXSource = ZoomSFXContainer.GetComponent<AudioSource>(); // ZoomSFX is the audiosource attached to ZoomSFXContainer gameobject
		ZoomSFXSource.playOnAwake = false;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R)) //If R is pressed
		{
			isZoomed = !isZoomed; // if camera is zoomed then unzoom
			SFXUpdater();
		}
		
		if (isZoomed) // if zoomed in
		{
			GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth); // zoom in
		}
		else // or else
		{
			GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth); // zoom out
		}
	}
	
	void SFXUpdater()
	{
		if (isZoomed)
		{
			ZoomSFXSource.Play(); //Play zooming sfx
		}
		else
		{
			ZoomSFXSource.Play(); //Play zooming sfx
		}
	}
}