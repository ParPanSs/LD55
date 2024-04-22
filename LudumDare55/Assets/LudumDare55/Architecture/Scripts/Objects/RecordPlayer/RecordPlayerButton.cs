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
        [SerializeField] private Animator cassetteAnimator;
        [SerializeField] private AudioSource buttonAudioSource;
        
        private void OnMouseDown()
        {
            if (recordPlayerAudioSource.clip == null) return;
            
            switch (buttonType)
            {
                case ButtonType.PlayButton:
                    if (!recordPlayerAudioSource.isPlaying)
                    {
                        recordPlayerAudioSource.Play();
                        buttonAnimator.SetTrigger("Click");
                        cassetteAnimator.Play("RecordPlayerCassettePlay");
                        buttonAudioSource.Play();
                    }
                    break;
                case ButtonType.PauseButton:
                    if (recordPlayerAudioSource.isPlaying)
                    {
                        recordPlayerAudioSource.Pause();
                        buttonAnimator.SetTrigger("Click");
                        cassetteAnimator.Play("RecordPlayerStatic");
                        buttonAudioSource.Play();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
