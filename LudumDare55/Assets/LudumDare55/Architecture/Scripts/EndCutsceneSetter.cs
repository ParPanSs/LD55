using System;
using UnityEngine;
using UnityEngine.Video;

public class EndCutsceneSetter : MonoBehaviour
{
    [SerializeField] private VideoClip[] cutscenes;
    [SerializeField] private VideoPlayer videoPlayer;

    private void Awake()
    {
        var playerScore = PlayerPrefs.GetInt("PlayerScore");
        
        switch (playerScore)
        {
            case 15:
                videoPlayer.clip = cutscenes[0];
                videoPlayer.Play();
                break;
            case 14:
                videoPlayer.clip = cutscenes[1];
                videoPlayer.Play();
                break;
            case 13:
                videoPlayer.clip = cutscenes[2];
                videoPlayer.Play();
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
