using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudumDare55
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private Bell _bell;

        public void SetFader()
        {
            animator.SetTrigger("Fader");
            StartCoroutine(ChangeScene());
        }

        private IEnumerator ChangeScene()
        {
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                                             && animator.GetCurrentAnimatorStateInfo(0).IsName("FaderIN")
                                             && !animator.IsInTransition(0));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}