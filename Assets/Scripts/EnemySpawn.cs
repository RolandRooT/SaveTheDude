using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Variables
    private float respawnTime;
    private Vector2 screenBound;
    private float time;

    public ObjectPooler theObjectPool;
    public ObjectPooler2 theObjectPool2;

    private void Start()
    {
        respawnTime = Random.Range(2f, 4f);
        time = respawnTime;
        
        //To give indication of screen boundaries
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Spawn enemy wave
        StartCoroutine(enemyWave());
    }
    private void Update()
    {
        // Respawn Time
        time = Time.time;
        if (time >= 10)
        {
            respawnTime = Random.Range(2f, 4f);
        }
        if (time >= 30)
        {
            respawnTime = Random.Range(2f, 3.6f);
        }

        if (time >= 60)
        {
            respawnTime = Random.Range(2f, 3f);
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

            GameObject enemies2 = theObjectPool2.GetPooledObject();
            enemies2.transform.position = new Vector2(screenBound.x, Random.Range(screenBound.y, -screenBound.y));
            enemies2.SetActive(true);


            //Flip Enemies 1
            Vector3 newScale = enemies1.transform.localScale;
            newScale.y = -1.6f;
            enemies1.transform.localScale = newScale;

        }

    }

}
