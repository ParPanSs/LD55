using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class CataloguePentagram
    {
        [SerializeField] private Sprite _sprite;
        public Sprite sprite => _sprite;
        
        public CataloguePentagram(Sprite sprite)
        {
            _sprite = sprite;
        }
    }
}
