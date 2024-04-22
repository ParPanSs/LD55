using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudumDare55
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetFader(bool type = true)
        {
            animator.SetTrigger("Fader");
            StartCoroutine(ChangeScene(type));
        }

        private IEnumerator ChangeScene(bool type)
        {
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                                             && animator.GetCurrentAnimatorStateInfo(0).IsName("FaderIN")
                                             && !animator.IsInTransition(0));
            switch (type)
            {
                case true:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
                case false:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    break;
            }
        }
    }
}