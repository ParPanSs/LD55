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
        
        public Pentagram(Sprite figure, Sprite drawing)
        {
            _figure = figure;
            _drawing = drawing;
        }
    }
}
