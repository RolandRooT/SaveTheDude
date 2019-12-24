using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemySpawn : MonoBehaviour
{
    //Variables
    private float respawnTime;
    private Vector2 screenBound;
    private float time;

    public BigObjectPooler theObjectPool;
    public BigObjectPooler2 theObjectPool2;
    private void Start()
    {
        respawnTime = Random.Range(7f, 12f);

        //To give indication of screen boundaries
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(enemyWave());
    }

    private void Update()
    {
        time = Time.time;
        if (time >= 10)
        {
            respawnTime = Random.Range(7f, 10f);
        }
        if (time >= 30)
        {
            respawnTime = Random.Range(7f, 9f);
        }
        if (time >= 60)
        {
            respawnTime = Random.Range(6f, 8f);
        }
    }


    IEnumerator enemyWave()
    {
        // Give loop to enemy spawn and time
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            GameObject enemies1 = theObjectPool.GetPooledObject();
            enemies1.transform.position = new Vector2(-screenBound.x, Random.Range(screenBound.y, -screenBound.y));
            enemies1.SetActive(true);

            GameObject enemies2 = theObjectPool2.GetPooledObject2();
            enemies2.transform.position = new Vector2(screenBound.x, Random.Range(screenBound.y, -screenBound.y));
            enemies2.SetActive(true);


            //Flip Enemies 1
            Vector3 newScale = enemies1.transform.localScale;
            newScale.y = -1.6f;
            enemies1.transform.localScale = newScale;
        }
    }
}
