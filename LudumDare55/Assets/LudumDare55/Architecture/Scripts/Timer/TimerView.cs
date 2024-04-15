using TMPro;
using UnityEngine;

namespace LudumDare55
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro[] digitTexts;
        [SerializeField] private Animator animator;
    
        public void DisplayTime(string displayTime)
        {
            for (var i = 0; i < digitTexts.Length; i++)
            {
                digitTexts[i].text = displayTime[i].ToString();
            }
        }

        public void SetRageAnimation()
        {
            animator.Play("TimerRunOutOfTime");
        }
    }
}
