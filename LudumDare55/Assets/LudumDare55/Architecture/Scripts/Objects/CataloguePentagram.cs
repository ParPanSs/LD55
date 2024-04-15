using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class CataloguePentagram
    {
        [SerializeField] private Sprite _figure;
        public Sprite figure => _figure;
        
        [SerializeField] private Sprite _drawing;
        public Sprite drawing => _drawing;
        
        public CataloguePentagram(Sprite figure, Sprite drawing)
        {
            _figure = figure;
            _drawing = drawing;
        }
    }
}
