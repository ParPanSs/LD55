using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private string _itemID;
        public string itemID => _itemID;
        
        [SerializeField] private Sprite _catalogueItemSprite;
        public Sprite catalogueItemSprite => _catalogueItemSprite;
        
        [SerializeField] private Sprite _inGameItemSprite;
        public Sprite inGameItemSprite => _inGameItemSprite;
        
        public Item(string itemID, Sprite catalogueItemSprite)
        {
            _itemID = itemID;
            _catalogueItemSprite = catalogueItemSprite;
        }
    }
}
