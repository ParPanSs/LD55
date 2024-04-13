using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class Pentagram
    {
        [SerializeField] private Sprite _figure;
        public Sprite figure => _figure;
        
        [SerializeField] private Sprite _drawing;
        public Sprite drawing => _drawing;
        
        [SerializeField] private Sprite _border;
        public Sprite border => _border;
        
        public Pentagram(Sprite figure, Sprite drawing, Sprite border)
        {
            _figure = figure;
            _drawing = drawing;
            _border = border;
        }
    }
}
