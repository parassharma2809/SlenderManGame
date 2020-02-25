//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.

using UnityEngine;
using System.Collections;

public class HintBox : MonoBehaviour {

	[Header("Random Number")]
	public float random; // random number
	
	[Header("Box Text")]
	public GameObject Hint1; // hint text 1
	public GameObject Hint2; // hint text 2
	public GameObject Hint3; // hint text 3
	public GameObject Hint4; // hint text 4
	public GameObject Hint5; // hint text 5
	
	void Start() {
		random = Random.Range (1f, 5f); // get random number between 1 and 5
	}

	void LateUpdate(){
		
		if (random <= 1f)  // if random number is = or < than 1
		{
			Hint1.SetActive(true); // hint text 1 enabled
			Hint2.SetActive(false); // hint text 2 disabled
			Hint3.SetActive(false); // hint text 3 disabled
			Hint4.SetActive(false); // hint text 4 disabled
			Hint5.SetActive(false); // hint text 5 disabled
		}
		else if (random <= 2f) // if random number is = or < than 2
		{
			Hint1.SetActive(false); // hint text 1 disabled
			Hint2.SetActive(true); // hint text 2 enabled
			Hint3.SetActive(false); // hint text 3 disabled
			Hint4.SetActive(false); // hint text 4 disabled
			Hint5.SetActive(false); // hint text 5 disabled
		}
		else if (random <= 3f) // if random number is = or < than 3
		{
			Hint1.SetActive(false); // hint text 1 disabled
			Hint2.SetActive(false); // hint text 2 disabled
			Hint3.SetActive(true); // hint text 3 enabled
			Hint4.SetActive(false); // hint text 4 disabled
			Hint5.SetActive(false); // hint text 5 disabled
		}
		else if (random <= 4f) // if random number is = or < than 4
		{
			Hint1.SetActive(false); // hint text 1 disabled
			Hint2.SetActive(false); // hint text 2 disabled
			Hint3.SetActive(false); // hint text 3 disabled
			Hint4.SetActive(true); // hint text 4 enabled
			Hint5.SetActive(false); // hint text 5 disabled
		}
		else if (random <= 5f) // if random number is = or < than 5
		{
			Hint1.SetActive(false); // hint text 1 disabled
			Hint2.SetActive(false); // hint text 2 disabled
			Hint3.SetActive(false); // hint text 3  disabled
			Hint4.SetActive(false); // hint text 4 disabled
			Hint5.SetActive(true); // hint text 5 enabled
		}
	}
}
