using UnityEngine;

namespace LudumDare55
{
    public class InGameCassetteObject : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsRecordPlayer;
        
        private AudioClip _cassetteAudioClip;
        private Vector2 _initialPosition;
        private AudioSource _recordPlayerAudioSource;
        private Animator _recordPlayerAnimator;
        
        public void Construct(AudioClip cassetteAudioClip)
        {
            _cassetteAudioClip = cassetteAudioClip;
        }

        private void OnMouseDown()
        {
            _initialPosition = transform.position;
        }
        
        private void OnMouseDrag()
        {
            var newPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = newPosition;
        }

        private void OnDestroy()
        {
            if (!_recordPlayerAudioSource) return;
            _recordPlayerAudioSource.Stop();
            _recordPlayerAudioSource.clip = null;
            _recordPlayerAnimator.Play("RecordPlayerOpen");
        }

        private void OnMouseUp()
        {
            var recordPlayer = Physics2D.OverlapCircle(transform.position, 1f, whatIsRecordPlayer);
            
            if (recordPlayer)
            {
                _recordPlayerAnimator = recordPlayer.GetComponent<Animator>();
                _recordPlayerAudioSource = recordPlayer.GetComponent<AudioSource>();
                _recordPlayerAudioSource.clip = _cassetteAudioClip;
                gameObject.SetActive(false);
                recordPlayer.GetComponent<Animator>().Play("RecordPlayerCassette");
                return;
            }
            
            transform.position = _initialPosition;
        }
    }
}