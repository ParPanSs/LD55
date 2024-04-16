using System;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare55
{
    [CreateAssetMenu(fileName = "Create Demon", menuName = "Scriptable Object/Create Demon")]
    public class CreateScriptableObjectOfDemon : ScriptableObject
    {
        // TODO: encapsulate fields
        public string demonID;
        
        public List<CatalogueItem> itemToSummon = new();
        public CataloguePentagram cataloguePentagram;
        public CatalogueCassette catalogueCassette;
        public Sprite catalogueDemonSprite;
    }
}
