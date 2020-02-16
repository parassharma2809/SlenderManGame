//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PageCounter : MonoBehaviour {

	 [Header("Page Setings")]
     public float Page = 0; //no. of pages with player
     public float pagesToWin = 8; //pages to win
	 
	 [Header("Score UI")]
	 public Text score; // reference to text object "score"
 
     void  Start ()
	 {
     } 
 
     void  Update ()
	 { 
	     if (Page < pagesToWin) // if no. of pages with player is less that pages to win
         {
             score.text = Page + "/8" + " Pages Collected"; // make the text display the no. of pages collected
         }
         else // or else
         {
             SceneManager.LoadScene("WinScene"); //Load scene 'WinScene'
         }
     } 
}