using System.Collections.Generic;
using UnityEngine;

namespace LudumDare55
{
    [CreateAssetMenu(fileName = "Create Demon", menuName = "Scriptable Object/Create Demon")]
    public class CreateScriptableObjectOfDemon : ScriptableObject
    {
        public List<Item> itemToSummon;
        public Sprite catalogueDemonSprite;
        public Sprite inGameDemonSprite;
        public Pentagram pentagram;
        public Cassette cassette;

        public string demonID;
    }
}
