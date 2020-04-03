//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PageSystem : MonoBehaviour {

	 [Header("<MoveSlender> Script Settings")]
	 public MoveSlender slenderai; //slender script
     public GameObject Slender; //slender model gameobject
	 
	 [Header("<PageCounter> Script Settings")]
	 public PageCounter pagecounter; //pagecounter script
     public GameObject PageCounter; //PageCounter gameobject
	 
	 [Header("Page Pickup SFX Settings")]
 	 public GameObject PagePickupSFXContainer; //the gameobject which contains the audiosource required
	 AudioSource PagePickupSFX; //pick up sfx for pages
	 
	 [Header("Page Pickup UI Settings")]
     public GameObject pickUpUI; //that prompt gameobject saying 'E to collect'
     
    [Header("Special Events Settings")]
    public SlenderWarning slenderWarning;
    public AmbianceController ambianceControl;
    public ScaryMusic ScaryMusic;
    public ScaryObjects ScaryObjects;

    void  Start ()
	 {
	 	slenderai = Slender.GetComponent<MoveSlender>(); // slenderai is the script <MoveSlender> attached to it
	 	pagecounter = PageCounter.GetComponent<PageCounter>(); // pagecounter is the script <PageCounter> attached to it
		PagePickupSFX = PagePickupSFXContainer.GetComponent<AudioSource>(); // PagePickupSFX is the audiosource attached to PagePickupSFXContainer gameobject
    } 
 
     void  Update ()
	 { 
     } 
	 
	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.tag == "Player") //If collider of this gameobject touches the gameobject with tag player
        {
            // Debug.Log("You Found a Page: " + collider.gameObject.name + ", Press 'E' to pickup");
            pickUpUI.SetActive(true); // enable that prompt gameobject saying 'E to collect'
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.transform.tag == "Player") //If collider of this gameobject touches the gameobject with tag player
        {
            if (Input.GetKeyDown(KeyCode.E)) //If E is pressed
            {
				PagePickupSFX.Play(); //Play pickup SFX
				
				slenderai.spawnRate -= 9; //decrease the spawn rate in <MoveSlender> by 9 so slender respawns faster and faster
				
				pagecounter.Page += 1; //increase the page count by 1 in <PageCounter>
				
                // Debug.Log("You get this page: " + pagecounter.Page);

                // disable UI
                pickUpUI.SetActive(false); // disable that prompt gameobject saying 'E to collect'

                // disable game object
                this.gameObject.SetActive(false); // disable the gameobject itself

                Debug.Log("EventLog " + System.DateTime.Now.ToString("HH:mm:ss") + " Page " + pagecounter.Page);

                if (pagecounter.Page == 1) //play ghost clip
                {
                    ScaryMusic.PlayGhostClip(3f);
                } else if(pagecounter.Page == 2)
                {
                    // Debug.Log("Triggering forced SlenderMan warning");
                    slenderWarning.triggerWarning();
                }
                else if(pagecounter.Page == 3) // play breathing clip
                {
                    ScaryMusic.PlayBreathingClip(3f);
                } else if(pagecounter.Page == 4) // change background music
                {
                    ambianceControl.ChangeClip();
                } else if(pagecounter.Page == 5) // slenderman teleport
                {
                    slenderai.Teleport();
                } else if(pagecounter.Page == 6) //dead bodies appear near all pages
                {
                    ScaryObjects.appear();
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.transform.tag == "Player") //If collider of this gameobject touches the gameobject with tag player
        {
            // disable UI
            pickUpUI.SetActive(false); // disable that prompt gameobject saying 'E to collect'
        }
    }
}