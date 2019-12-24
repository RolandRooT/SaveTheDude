using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowLeaderboardsUI()
    {
        PlayServices.instance.ShowLeaderboardsUI();
    }

    public void ShowAchievements()
    {
        PlayServices.instance.ShowAchievementsUI();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
