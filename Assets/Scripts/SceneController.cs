using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Text yourScore;

    public void Start()
    {
        yourScore.text = "" + PlayerPrefs.GetFloat("YourScore");
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
