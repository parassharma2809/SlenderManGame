//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.
//Simple script to teleport Slender. This script is made to be used in an open and plain area like a forest.
//Don't use this script if working with irregular terrain as slender may spawn between terrains.
//To make slender teleport on irregular surface please look forward to the final paid version of this asset.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class MoveSlender: MonoBehaviour {

	[Header("Player Settings")]
	GameObject Player; // gameobject player
	Transform player; // the Object the player is controlling
	
	[Header("Enemy Location Settings")]
	public GameObject FrontSpawn; // gameobject cube
	Transform frontspawn; // the cube transform 
	public GameObject BaseSpawn; // gameobject cube
	Transform basespawn; // the cube transform 
	Vector3 spawnOrgin; // this will be the transform of the cube
	Vector3 maximum; // max distance in the x, y, and z direction the enemy can spawn
	
	[Header("Enemy Calculations Settings")]
	public float spawnRate = 80.0f; // how often the enemy will respawn
	float distanceToPlayer = 12.5f; // how close the enemy has to be to the player to play music
	public float facePlayerfactor = 20f; // angle of facing player
	private float nextTeleport = 10.0f; // will keep track of when we to teleport next
	
	[Header("Booleans")]
	private bool nearPlayer = false; // use this to stop the teleporting if near the player
	private bool collided = false; // use this to keep track of collision with the obstacle

	void Start() {
		Player = GameObject.FindWithTag("Player"); // find the gameobject with the tag of Player.
		player = Player.GetComponent<Transform>(); // from the gameobject of player get the transform
		frontspawn = FrontSpawn.GetComponent<Transform>(); // get the transform from the gameobject Cube
		basespawn = BaseSpawn.GetComponent<Transform>(); // get the transform from the gameobject Cube
		nextTeleport = spawnRate; // update the time to teleport	
	}

	void Update() {
		bool inView = Vector3.Dot(Vector3.forward, player.InverseTransformPoint(transform.position)) > 0; // player is in view
		
		maximum.Set(basespawn.position.x, 3.31f, basespawn.position.z); //  max distance in the x, y, and z direction the enemy can spawn is 5, 3.31, 5
		spawnOrgin.Set(frontspawn.position.x, 3.31f, frontspawn.position.z); // slender's spawn origin
		
		FacePlayer(); // face player no matter what
		
		if (!(nearPlayer || inView)) // only teleport if we are not close to the player and not in it's view
		{
			if (Time.time > nextTeleport) // only teleport if enough time has passed
			{
				transform.position = new Vector3 (Random.Range(spawnOrgin.x, maximum.x), Random.Range(spawnOrgin.y, maximum.y), Random.Range(spawnOrgin.z, maximum.z)); // teleport
				if (collided == false)
				{
					Debug.Log("Slender didn't collide with any obstacle, updating the next time to teleport");
					nextTeleport += spawnRate; // update the next time to teleport	
				}
				else
				{
					Debug.Log("Slender has collided with an obstacle, teleporting him to a new location");
					transform.position = new Vector3 (Random.Range(spawnOrgin.x, maximum.x), Random.Range(spawnOrgin.y, maximum.y), Random.Range(spawnOrgin.z, maximum.z)); // teleport
					nextTeleport += spawnRate; // update the next time to teleport	
				}
			}
		}
		
		// The breathing sfx
		if (Vector3.Distance(transform.position, player.position) <= distanceToPlayer) // if near player
		{
			if (GetComponent<AudioSource>() && GetComponent<AudioSource>().clip && !GetComponent<AudioSource>().isPlaying && inView) // play the audio if it isn't playing and slender is in view
			{
			GetComponent<AudioSource>().Play();
			nearPlayer = true;
			}
		}
		else 
		{
			if (GetComponent<AudioSource>())  // stop the audio if it is playing and slender isn't in view
			{
			GetComponent<AudioSource>().Stop();
			nearPlayer = false;
			}
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.transform.tag == "Obstacle") //If collider of this gameobject touches the gameobject with tag Obstacle
		{
			collided = true;
		}
	}
	
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.transform.tag == "Obstacle") //If collider of this gameobject touches the gameobject with tag Obstacle
		{
			collided = false;
		}
	}
	
	// The function to make slender face player
	void FacePlayer()
	{
		Vector3 direction = (player.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerfactor);
	}
}