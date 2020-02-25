//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadIntro : MonoBehaviour
{
	[SerializeField]
	[Header("Time Settings")]
	private float delayBeforeLoading = 10f; // time before loading
	private float timeElapsed; // time elapsed
    
    private void Update()
    {
        timeElapsed += Time.deltaTime; // add time to time elapsed
	    
	if (timeElapsed > delayBeforeLoading) // if time elapsed is greater than time before loading
	{
		SceneManager.LoadScene("Intro"); // load intro scene
	}
    }
}
