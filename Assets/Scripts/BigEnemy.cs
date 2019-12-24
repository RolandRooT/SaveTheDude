using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    //Variables
    public Transform target;
    public float moveSpeed = 1f;
    public float invisLength = 1f;
    public float invisDuration = 1f;
    public Renderer enemyRenderer;

    private int randomSpot;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Get rigidbody component when game start
    private void Start()
    {
        moveSpeed = Random.Range(0.1f, 0.6f);
        rb = this.GetComponent<Rigidbody2D>();

        invisLength = Random.Range(0f, 10f);
        invisDuration = Random.Range(0f, 10f);
    }


    // Turn angle and direction to the target
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle2;
        direction.Normalize();
        movement = direction;

        //invisible
        invisLength -= Time.deltaTime;
        invisDuration -= Time.deltaTime;
        if (invisLength < 0.1f)
        {
            enemyRenderer.enabled = false;
            if (invisDuration <= 2)
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
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
