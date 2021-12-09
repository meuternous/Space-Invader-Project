using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public int HP;
    public int score;
    public int maxHP;

    public float PlayerSpeed;
    public float PlayerPosition;
    public float leftBorder;
    public float rightBorder;

    public UnityEngine.Object BulletPrefab;

    // Use this for initialization
    void Start () {
        if (rightBorder == 0)
        {
            rightBorder -= leftBorder;
        }
        else if (leftBorder == 0)
        {
            leftBorder -= rightBorder;
        }
    }
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
    }

    private void MovePlayer()
    {
        PlayerPosition = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(PlayerPosition*Time.deltaTime*PlayerSpeed, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, leftBorder, rightBorder);
        transform.position = newPosition;
        FireBullet();
    }

    public float bulletCharge = 0;

    private void FireBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        if (Input.GetButton("Fire1"))
        {
            bulletCharge += 0.05f;
        }
        if (Input.GetButtonUp("Fire1") || bulletCharge >= 7)
        {
            if (bulletCharge > 1)
            {
                GameObject GO = (GameObject)Instantiate(BulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                GO.transform.localScale = new Vector3(bulletCharge*0.25f,bulletCharge*0.35f,bulletCharge*0.25f);
                //Instantiate(GO);

            }
            bulletCharge = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DestroyMe();
        }
    }

    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
