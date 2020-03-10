using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceController : MonoBehaviour
{
    public AudioSource ambience;
    public AudioClip clip1;
    public AudioClip clip2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeClip()
    {
        if(ambience.clip == clip1)
        {
            ambience.clip = clip2;
            ambience.Play();
        }
        else
        {
            ambience.clip = clip1;
            ambience.Play();
        }
    }
}
