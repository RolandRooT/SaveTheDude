using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int playerLife;
    public GameObject[] playerHearts;
    
    private void Update()
    {
        if (playerLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }  
    }


    // Load Game over scene when enemy collide
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NormalEnemy"))
        {
            HurtPlayer();

            for (int i = 0; i < playerHearts.Length; i++)
            {
                if (playerLife > i)
                {
                    playerHearts[i].SetActive(true);
                }
                else
                {
                    playerHearts[i].SetActive(false);
                }
            }
        }

        else if (other.CompareTag("BigEnemy"))
        {
            HurtPlayer();

            for (int i = 0; i < playerHearts.Length; i++)
            {
                if (playerLife > i)
                {
                    playerHearts[i].SetActive(true);
                }
                else
                {
                    playerHearts[i].SetActive(false);
                }
            }
        }
    }

    private void HurtPlayer()
    {
        playerLife -= 1;
    }
}
