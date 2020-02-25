//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.
//This script will basically detect if any key or mouse button has been pressed.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnyKeyPress : MonoBehaviour {
	
	void Start() {
	}

	void Update()
	{
		if (Input.anyKey)
		{
			SceneManager.LoadScene("Menu"); //Load scene 'Menu'
		}
	}
}