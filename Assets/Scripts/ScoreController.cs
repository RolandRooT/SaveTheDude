using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Variables
    public int score;
    public Text scoreText;

    // Add score points
    public void Update()
    {
        scoreText.text = ""+score;
    }
    public void AddScoreSmall()
    {
        score += 10;
        PlayerPrefs.SetFloat("YourScore", score);
    }

    public void AddScoreBig()
    {
        score += 50;
        PlayerPrefs.SetFloat("YourScore", score);
    }

}


