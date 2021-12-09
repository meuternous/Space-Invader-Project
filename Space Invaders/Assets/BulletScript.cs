using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float bulletSpeed;
    public int bulletHP = 1;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        bulletSpeed = 7;
        bulletHP = (int)(((double)transform.localScale.y * (double)transform.localScale.y)/0.125);
    }
	
	// Update is called once per frame
	void Update () {
        MoveBullet();
        //OutOfRange();
	}

    /*private void OutOfRange()
    {
        if (transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }*/

    private void MoveBullet()
    {
        Vector3 bulletPosition = transform.position;
        bulletPosition.y += Time.deltaTime*bulletSpeed;
        transform.position = bulletPosition;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            audioSource.Play();
            bulletHP--;
            if (bulletHP <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.tag == "Border")
        {
            Destroy(gameObject);
        }
        
    }
}
