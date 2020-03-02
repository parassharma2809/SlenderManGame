//Script written by Pratyush Priyadarshi.
//Contact on pratyushpriyadarshiofficial@gmail.com if any changes required.
//You are free to use this script in any project until and unless you have not legally downloaded the asset package from itch.io.
//Please edit to suit your changes

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menubutton : MonoBehaviour
{
	[Header("Panels")]
	public GameObject Menu; // get the gameobject menu panel
    /*
	public GameObject Credits; // get the gameobject credits panel
    
    public void CreditsOpen() // if credit is opened
    {
	Credits.SetActive(true); // credits panel is set active
	Menu.SetActive(false); // menu panel is disabled
    }
    
    public void MenuOpen() // if menu is opened
    {
	Credits.SetActive(false); // credits panel is disabled
	Menu.SetActive(true); // menu panel is set active
    }*/
    
    public void Loading() // if play button is clicked
    {
       SceneManager.LoadScene("Loading"); // load the loading scene
    }
     
    public void Quit() // if quit button is clicked
    {
        Application.Quit(); // quit
    }
    
    /*
    public void Rate() // if rate button is clicked
    {
        Application.OpenURL("https://ppthebestofficial.itch.io/slendertheend"); // open your rating site
    }
    
    public void YT() // if youtube icon is clicked
    {
        Application.OpenURL("https://www.youtube.com/channel/UCdAhAWQpZ62mAAWJSuUpfew?"); // open your youtube channel
    }
    
    public void DC() // if discord icon is clicked
    {
        Application.OpenURL("https://discord.gg/wcDJ5CF"); // send invitation to join your discord server
    }*/
}