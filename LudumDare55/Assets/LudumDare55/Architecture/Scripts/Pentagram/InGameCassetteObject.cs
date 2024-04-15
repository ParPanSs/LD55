using System;
using UnityEngine;

namespace LudumDare55
{
    public class InGameCassetteObject : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsRecordPlayer;
        
        private AudioClip _cassetteAudioClip;
        private Vector2 _initialPosition;
        private AudioSource _recordPlayerAudioSource;
        
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
        }

        private void OnMouseUp()
        {
            var recordPlayer = Physics2D.OverlapCircle(transform.position, 1f, whatIsRecordPlayer);
            
            if (recordPlayer)
            {
                _recordPlayerAudioSource = recordPlayer.GetComponent<AudioSource>();
                _recordPlayerAudioSource.clip = _cassetteAudioClip;
                gameObject.SetActive(false);
                return;
            }
            
            transform.position = _initialPosition;
        }
    }
}