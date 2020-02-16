//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyDetector : MonoBehaviour {

    [Header("Enemy")]
	GameObject Enemy; // gameobject enemy
	Transform enemy; // the Object the enemy is controlling

	[Header("Glitch/Static Effect Settings")]
    public AudioClip StaticSFX; //the static noise
	public Camera PlayerCam; //Player's camera
	public GlitchEffect glitch; //Glitch effect
 	public GameObject StaticSFXContainer; //the gameobject which contains the audiosource required
	AudioSource StaticSFXSource; //audiosource required
	
	[Header("View Settings")]
	public float maxLookDuration = 5.0f; // How long can the player look before dying? (seconds)
	public float counterFalloff = 1f; // How quickly does counter fall go back down to zero when not looking at enemy? 
	private float lookDuration = 0.0f; // How long the player has been looking at the enemy. 
	public float distanceToEnemy = 50f; // how close the enemy has to be to the player to increment the counter
	
	void Start()
	{
		Enemy = GameObject.FindWithTag("Enemy"); // enemy is the gameobject with the tag 'Enemy'
		enemy = Enemy.GetComponent<Transform>(); // get the transform from gameobject Enemy
		glitch = PlayerCam.GetComponent<GlitchEffect>(); // glitch is the script <GlitchEffect> attached to PlayerCam
		StaticSFXSource = StaticSFXContainer.GetComponent<AudioSource>(); // PageSFX is the audiosource attached to PageSFXContainer gameobject
	}
	
	void Update()
	{
		Vector3 targetDir = enemy.position - transform.position;
		float angleToEnemy = (Vector3.Angle(targetDir, transform.forward));
 
		if (angleToEnemy >= -41 && angleToEnemy <= 41 && Vector3.Distance(enemy.position, transform.position) <= distanceToEnemy && IsObscured(enemy) == false) // If enemy is in our 82° FOV and is not to far far from player and is visble
		{
			// Player is looking at enemy, increment counter.
			StaticSFXSource.PlayOneShot(StaticSFX);
			glitch.intensity = 1;
			glitch.flipIntensity = 1;
			glitch.colorIntensity = 0.3f;
			lookDuration += Time.deltaTime;
			Debug.Log("Slender is visible");

			// Player has looked at enemy for too long, die.
			if (lookDuration > maxLookDuration) 
			{
				Die();
			}
			
		} 
		else if (lookDuration > 0f) 
		{
			// Player is not looking at enemy, allow counter to drop back down.
			glitch.intensity = 0;
			glitch.flipIntensity = 0;
			glitch.colorIntensity = 0;
			lookDuration = Mathf.Max(lookDuration - Time.deltaTime * counterFalloff, 0f);
			StaticSFXSource.Stop();
		}
		
		Debug.Log("look duration = " + lookDuration);
	}
	
	bool IsObscured(Transform target) 
	{
		// Check line of sight to target.
		// If a raycast from viewer to target hits something else inbetween, it is considered obscured.
		// This will hit any collider, so a layermask may be needed.
		RaycastHit hit;
		if (Physics.Linecast(transform.position, target.position, out hit)) {
			// The ray has hit the enemy. It can be seen!
			if (hit.transform == target) return false;
		}
		// The ray has hit some other thing (or nothing at all)
		return true;
	}
	
	void Die() 
	{
		SceneManager.LoadScene("DeathScene"); //Load scene 'DeathScene'
	}
}