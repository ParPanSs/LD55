using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class Cassette
    {
        [SerializeField] private AudioClip _cassetteAudio;
        [SerializeField] private string[] _cassetteAudioCharacteristics;

        public Cassette(AudioClip cassetteAudio, string[] cassetteAudioCharacteristics)
        {
            _cassetteAudio = cassetteAudio;
            _cassetteAudioCharacteristics = cassetteAudioCharacteristics;
        }

        public AudioClip GetAudioClip()
        {
            return _cassetteAudio;
        }

        public string GetDescription()
        {
            return string.Join(" ", _cassetteAudioCharacteristics);
        }
    }
}


