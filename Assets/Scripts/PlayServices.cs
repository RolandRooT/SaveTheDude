using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour
{
    public static PlayServices instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        SignIn();

    }

    private void SignIn()
    {
        Social.localUser.Authenticate(success =>
        {

        });
    }

    #region Achievements
    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, (bool success) =>
          {

          });
    }

    public void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, succes => { });
    }

    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }

    #endregion

    #region Leaderboards
    public void AddScoreToLeaderBoards(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success =>
        {

        });
    }

    public void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion

}
