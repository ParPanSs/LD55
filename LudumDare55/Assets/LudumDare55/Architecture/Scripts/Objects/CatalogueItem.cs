using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class CatalogueItem
    {
        [SerializeField] private Sprite _itemSprite;
        public Sprite itemSprite => _itemSprite;
        
        public CatalogueItem(Sprite itemSprite)
        {
            _itemSprite = itemSprite;
        }
    }
}
