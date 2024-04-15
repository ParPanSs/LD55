using System;
using UnityEngine;

namespace LudumDare55
{
    public class RecordPlayerButton : MonoBehaviour
    {
        private enum ButtonType
        {
            PlayButton,
            PauseButton
        }
    
        [SerializeField] private AudioSource recordPlayerAudioSource;
        [SerializeField] private ButtonType buttonType;
        [SerializeField] private Animator buttonAnimator;
        
        private void OnMouseDown()
        {
            switch (buttonType)
            {
                case ButtonType.PlayButton:
                    if (!recordPlayerAudioSource.isPlaying)
                    {
                        recordPlayerAudioSource.Play();
                        //buttonAnimator.Play();
                    }
                    break;
                case ButtonType.PauseButton:
                    if (recordPlayerAudioSource.isPlaying)
                    {
                        recordPlayerAudioSource.Pause();
                        //buttonAnimator.Play();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
