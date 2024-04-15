using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGamePentagram
    {
        [SerializeField] private Sprite _figure;
        public Sprite figure => _figure;
        
        [SerializeField] private Sprite[] _drawings;
        public Sprite[] drawings => _drawings;
        
        public InGamePentagram(Sprite figure, Sprite[] drawings)
        {
            _figure = figure;
            _drawings = drawings;
        }
    }
}
