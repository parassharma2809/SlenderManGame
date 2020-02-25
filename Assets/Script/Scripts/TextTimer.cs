//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.using UnityEngine;

 using UnityEngine;
 using System.Collections;
 
 public class TextTimer : MonoBehaviour
 {
 	 [Header("Next Display Settings")]
     public float time = 5; //Seconds to read the text
	 public GameObject nextText; //Next text to display
 
     IEnumerator Start ()
     {
         yield return new WaitForSeconds(time); // wait for time
         Destroy(gameObject); // after some time, destroy this gameobject
		 nextText.SetActive(true); // enable the next text to display
     }
 }