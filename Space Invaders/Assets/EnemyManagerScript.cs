using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerScript : MonoBehaviour {

    public GameObject EnemyPrefab;

    public GameObject[,] enemies;
    
    public int rows = 100;
    public int columns = 10;


    private float leftBorder = -4;
    private float rightBorder = 4;
    private float moveSpeed = 2;
    public int dir = 1;
    private float dropAmount = 1f;

    public int score = 0;

    public Text scoreText;

    // Use this for initialization
    void Start() {

        enemies = new GameObject[(int)columns, (int)rows];

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                CreateEnemy(c, r);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        moveEnemy();
        score = 0;
        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                if (!enemies[c,r].active)
                {
                    score++;
                }
            }
        }
        scoreText.text = "Score: " + score + " / " + (columns * rows);
    }
    public void Init()
    {
        
    }

    void CreateEnemy(float x, float y)
    {
        enemies[(int)x, (int)y] = Instantiate(EnemyPrefab, new Vector3(x-(columns/2)+0.5f, y+5.5f, 2), Quaternion.identity);
        enemies[(int)x, (int)y].transform.parent = this.transform;
    }
    private void moveEnemy()
    {
        Vector3 enemyPosition = transform.position;
        enemyPosition.x += moveSpeed * Time.deltaTime * dir;
        enemyPosition.x = Mathf.Clamp(enemyPosition.x, leftBorder, rightBorder);
        if (enemyPosition.x <= leftBorder)
        {
            dir = 1;
            enemyPosition.y -= dropAmount;
        }
        if (enemyPosition.x >= rightBorder)
        {
            dir = -1;
            enemyPosition.y -= dropAmount;
        }

        transform.position = enemyPosition;

        moveSpeed += 0.0001f;
    }
}
