//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PageMusic : MonoBehaviour {

	 [Header("<PageCounter> Script Settings")]
	 public PageCounter pagecounter; //pagecounter script
     public GameObject PageCounter; //PageCounter gameobject
	 
	 [Header("Page Pickup Music Settings")]
 	 public GameObject PageSFXContainer; //the gameobject which contains the audiosource required
	 AudioSource PageSFX; //pick up heart beat music for pages
	 
     void  Start ()
	 {
	 	 pagecounter = PageCounter.GetComponent<PageCounter>(); // pagecounter is the script <PageCounter> attached to it
		 PageSFX = PageSFXContainer.GetComponent<AudioSource>(); // PageSFX is the audiosource attached to PageSFXContainer gameobject
     } 
 
     void  Update ()
	 { 
	     if (pagecounter.Page == 0) // if no. of pages with player is 1 (0 written here bcz it works with 0, you can write 1)
         {
             PageSFX.Play(); //Play pickup music
         }
     } 
}