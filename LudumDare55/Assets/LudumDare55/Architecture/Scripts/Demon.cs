using UnityEngine;

namespace LudumDare55
{
    
    [System.Serializable]
    public class Demon
    {
        public string demonID;
        public string demonName;
        public CatalogueItem[] itemToSummon;
        public CataloguePentagram cataloguePentagram;
        public CatalogueCassette catalogueCassette;
        public Sprite catalogueDemonSprite;
    }
}