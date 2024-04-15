using UnityEngine;

namespace LudumDare55
{
    public class InGameItemObject : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void PlayAnimation()
        {
            _animator.SetTrigger("Dissapear");
        }
    }
}