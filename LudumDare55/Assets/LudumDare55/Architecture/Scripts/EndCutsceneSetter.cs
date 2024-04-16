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
        
        switch (playerScore)
        {
            case 15:
                videoPlayer.url = cutscenes[0];
                videoPlayer.Play();
                break;
            case 14:
                videoPlayer.url = cutscenes[1];
                videoPlayer.Play();
                break;
            case 13:
                videoPlayer.url = cutscenes[2];
                videoPlayer.Play();
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
