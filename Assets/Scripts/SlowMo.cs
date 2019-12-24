using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    private float fixedDeltaTime;
    private SmallEnemy enemySpeed;
    private BigEnemy bigEnemySpeed;
    void Start()
    {
        GameObject normalEnemy = GameObject.Find("NormalEnemy1");
        GameObject bigEnemy = GameObject.Find("BigEnemy1");

        SmallEnemy enemy = normalEnemy.GetComponent<SmallEnemy>();
        BigEnemy enemyBig = bigEnemy.GetComponent<BigEnemy>();

        enemy = enemySpeed;
        enemyBig = bigEnemySpeed;
    }

    private void OnMouseDown()
    {
        enemySpeed.moveSpeed = 0f;
        bigEnemySpeed.moveSpeed = 0f;

    }
}
