using UnityEngine;

namespace LudumDare55
{
    [CreateAssetMenu(fileName = "New Setup", menuName = "Scriptable Object/Create Setup")]
    public class CreateScriptableObjectOfSetup : ScriptableObject
    {
        // TODO: encapsulate fields
        public string thisSetupId;
        public string demonSetupId;
        public InGameItem[] setupItems;   
        public InGamePentagram setupCataloguePentagram;
        public InGameCassette setupCassette;
    }
}