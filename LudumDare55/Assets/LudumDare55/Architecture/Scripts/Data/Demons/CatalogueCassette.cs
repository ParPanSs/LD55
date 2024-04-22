using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class CatalogueCassette
    {
        [SerializeField] private string[] _cassetteAudioCharacteristics;

        public CatalogueCassette(AudioClip cassetteAudio, string[] cassetteAudioCharacteristics)
        {
            _cassetteAudioCharacteristics = cassetteAudioCharacteristics;
        }

        public string GetDescription()
        {
            return string.Join("\n", _cassetteAudioCharacteristics);
        }
    }
}


