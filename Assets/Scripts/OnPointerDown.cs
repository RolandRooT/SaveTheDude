using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPointerDown : MonoBehaviour
{
    public GameObject mainBody;
    private bool pointerDown;
    private float pointerDownTimer;
    public GameObject deathEffect;
    public GameObject holdEffect;
    public GameObject killEffect;


    public float nextSpawnTime;
    public float requiredHoldTime = 0.8f;
    private ScoreController score;

    private Shake shake;
    private void Start()
    {
        score = FindObjectOfType<ScoreController>();
        nextSpawnTime = Time.time;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void OnMouseDown()
    {
        pointerDown = true;  
    }

    private void Update()
    {

        if (pointerDown)
        {
            
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime += 0.3f;
                HoldEffect();
            }

            // If the player hold the enemy long enough, it will destroy it
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                DeathEffect();
                Reset();
                mainBody.SetActive(false);
                score.AddScoreBig();

            }
            
        }
       
    }

    //Collide with player will trigger the VFX and set the gameobject off

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KillEffect();
            mainBody.SetActive(false);
        }
    }

    // Reset the hold timer
    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;

    }
    private void OnMouseUp()
    {
        Reset();
    }

    public void DeathEffect()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        shake.CamShake();
    }

    public void HoldEffect()
    {
        Instantiate(holdEffect, transform.position, transform.rotation);
    }

    public void KillEffect()
    {
        Instantiate(killEffect, transform.position, transform.rotation);

    }
}
