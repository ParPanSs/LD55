using UnityEngine;

namespace LudumDare55
{
    [CreateAssetMenu(fileName = "New Setup", menuName = "Scriptable Object/Create Setup")]
    public class CreateScriptableObjectOfSetup : ScriptableObject
    {
        // TODO: encapsulate fields
        public float SetupTime = 120f;
        public Item[] setupItems;   
        public Pentagram setupPentagram;
        public Cassette setupCassete;
    }
}