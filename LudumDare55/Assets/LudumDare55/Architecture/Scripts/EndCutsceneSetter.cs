using System;
using UnityEngine;
using UnityEngine.Video;

public class EndCutsceneSetter : MonoBehaviour
{
    [SerializeField] private string[] cutscenes;
    [SerializeField] private VideoPlayer videoPlayer;
    
    private void Awake()
    {
        var playerScore = PlayerPrefs.GetInt("PlayerScore");
        string urlPath;
        
        switch (playerScore)
        {
            case 15:
                urlPath = cutscenes[0];
                break;
            case 14:
                urlPath = cutscenes[1];
                videoPlayer.Play();
                break;
            case 13:
                urlPath = cutscenes[2];
                videoPlayer.Play();
                break;
            default:
                throw new NotImplementedException();
        }
        
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, urlPath);
        videoPlayer.Play();
    }
}
