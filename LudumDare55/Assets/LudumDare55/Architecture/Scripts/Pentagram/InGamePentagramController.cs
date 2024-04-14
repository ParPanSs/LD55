using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGamePentagramController
    {
        [SerializeField] private InGamePentagramView inGamePentagramView;

        public void SetSetup(CreateScriptableObjectOfSetup setup)
        {
            inGamePentagramView.DisplaySetup(setup);
        }
    }
}