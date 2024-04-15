using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGameItem
    {
        [SerializeField] private GameObject _itemObject;
        public GameObject itemObject => _itemObject;
        
        public InGameItem(GameObject itemObject)
        {
            _itemObject = itemObject;
        }
    }
}
