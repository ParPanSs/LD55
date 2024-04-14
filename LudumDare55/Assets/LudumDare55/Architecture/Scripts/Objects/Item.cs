using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private Sprite _itemSprite;
        public Sprite itemSprite => _itemSprite;
        
        public Item(Sprite itemSprite)
        {
            this._itemSprite = itemSprite;
        }
    }
}
