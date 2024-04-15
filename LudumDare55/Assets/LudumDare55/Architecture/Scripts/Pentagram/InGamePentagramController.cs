using UnityEngine;

namespace LudumDare55
{
    public class InGamePentagramController
    {
        private InGamePentagramView _inGamePentagramView;

        public void Construct(InGamePentagramView inGamePentagramView)
        {
            _inGamePentagramView = inGamePentagramView;
        }

    public void SetSetup(CreateScriptableObjectOfSetup setup)
        {
            _inGamePentagramView.DisplaySetup(setup);
        }

        public void ClearSetup()
        {
            _inGamePentagramView.ClearSetup();
        }
    }
}