using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
          .Build();
        PlayGamesPlatform.InitializeInstance(config);

        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        // authenticate user:
        Social.localUser.Authenticate((bool success) =>
        {
            // handle success or failure
        });
    
    }

}
