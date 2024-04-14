using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGamePentagramController
    {
        [SerializeField] private InGamePentagramView inGamePentagramView;

        public void SetSetup(object sender, CreateScriptableObjectOfSetup setup)
        {
            inGamePentagramView.DisplaySetup(setup);
        }
    }
}