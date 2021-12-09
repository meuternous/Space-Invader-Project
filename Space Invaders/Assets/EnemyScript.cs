using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public bool Active;
    public float sizeScale = 1;
    public float hp = 4;
    public float leftBorder = -7;
    public float rightBorder = 7;
    private float moveSpeed = 2;
    public int dir = 1;
    private float dropAmount = 1f;



    /*enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }*/

    // Use this for initialization
    void Start () {
        //sizeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //moveEnemy();
	}

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                DestroyMe();
            }
        }
    }

    private void DestroyMe()
    {
        Active = false;
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
