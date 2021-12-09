using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static SoundManagerScript instance;
    public AudioSource audioSource;
    public AudioClip hitEnemy;
    public AudioClip killEnemy;
    public AudioClip killPlayer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playAudio()
    {
        
            audioSource.PlayOneShot(hitEnemy);
        
        //else if
    }
}
