using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private string _itemID;
        public string itemID => _itemID;
        
        [SerializeField] private Sprite _itemSprite;
        public Sprite itemSprite => _itemSprite;

        public Item(string itemID, Sprite itemSprite)
        {
            _itemID = itemID;
            _itemSprite = itemSprite;
        }
    }
}
