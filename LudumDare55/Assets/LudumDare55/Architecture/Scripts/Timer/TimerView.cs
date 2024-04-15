using TMPro;
using UnityEngine;

namespace LudumDare55
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro[] digitTexts;
        [SerializeField] private Animator animator;
        [SerializeField] private AudioClip[] timerSounds;
        [SerializeField] private AudioSource timerSoundsPlayer;
        [SerializeField] private AudioSource timerWrongBeeper;
        [SerializeField] private Animator minusTimeAnimator;

        private void Start()
        {
            timerSoundsPlayer = GetComponent<AudioSource>();
        }
        public void DisplayTime(string displayTime)
        {
            for (var i = 0; i < digitTexts.Length; i++)
            {
                digitTexts[i].text = displayTime[i].ToString();
            }
        }

        public void PlayPunishmentSound()
        {
            timerWrongBeeper.Play();
            minusTimeAnimator.Play("MinusTime");
        }
        
        public void SetRageAnimation()
        {
            animator.Play("TimerRunOutOfTime");
            timerSoundsPlayer.clip = timerSounds[1];
            timerSoundsPlayer.Play();
        }
    }
}
