using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare55
{
    [System.Serializable]
    public class RoundStarter
    {
        [SerializeField] private List<CreateScriptableObjectOfSetup> setups;
        private InGamePentagramController _inGamePentagramController;
        private MonoBehaviour _ejector = new();
        public string rightDemon { get; private set; }
        public int setupsCount { get; private set; }

        public void Construct(InGamePentagramController inGamePentagramController)
        {
            _inGamePentagramController = inGamePentagramController;
            StartNewRound();
        }
        
        public void StartNewRound()
        {
            _ejector.Invoke(nameof(StartNewRoundWithDelay), 3f);
        }

        private void StartNewRoundWithDelay()
        {
            var newSetup = setups[Random.Range(0, setups.Count)];
            _inGamePentagramController.SetSetup(newSetup);
            rightDemon = newSetup.demonSetupID;
            setups.Remove(newSetup);
        }
    }
}
