using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    //Variables
    public GameObject mainBody;
    public Transform target;
    public float moveSpeed = 1f;
    public float invisLength = 1f;
    public float invisDuration = 1f;
    public Renderer enemyRenderer;
    public GameObject deathEffect;
    public GameObject killEffect;


    private int randomSpot;
    private Rigidbody2D rb;
    private Vector2 movement;
    private ScoreController score;


    // Get rigidbody component when game start
    private void Start()
    {
        moveSpeed = Random.Range(0.1f, 1f);
        rb = this.GetComponent<Rigidbody2D>();
        score = FindObjectOfType<ScoreController>();
        invisLength = Random.Range(0f, 10f);
        invisDuration = Random.Range(0f, 10f);
    }

    // Turn angle and direction to the target
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        //invisible
        invisLength -= Time.deltaTime;
        invisDuration -= Time.deltaTime;
        if (invisLength < 0.1f)
        {
            enemyRenderer.enabled = false;
            if(invisDuration <= 2)
            {
                enemyRenderer.enabled = true;
            }
        }
        else if (invisLength >= 0.1f)
        {
            enemyRenderer.enabled = true;
        }
    }

    // Reference moveCharacter function to movement Vector2
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    // Move the enemy towards target direction
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    // Kill enemy and add score
    private void OnMouseDown()
    {
        DeathEffect();
        mainBody.SetActive(false);
        score.AddScoreSmall();
    }
    
    public void DeathEffect()
    {

        Instantiate(deathEffect, transform.position, transform.rotation);

    }

    public void KillEffect()
    {
        Instantiate(killEffect, transform.position, transform.rotation);
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
}
