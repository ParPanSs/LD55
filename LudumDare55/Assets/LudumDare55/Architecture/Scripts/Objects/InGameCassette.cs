using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGameCassette
    {
        [SerializeField] private AudioClip _cassetteAudio;
        public AudioClip cassetteAudio => _cassetteAudio;
        
        public InGameCassette(AudioClip cassetteAudio)
        {
            _cassetteAudio = cassetteAudio;
        }
    }
}


