//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.
//This script is not used in the project, but I added it because many people had confusion regarding DontDestroyOnLoad.
//How to use: Just add this script on your gameobject which you don't want to destroy between scenes.

using UnityEngine;
using System;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
 
     void  Start ()
	 {
	 	DontDestroyOnLoad(this.gameObject);
     } 
}