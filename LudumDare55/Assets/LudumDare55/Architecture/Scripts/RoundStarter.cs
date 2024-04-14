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
        public string rightDemon { get; private set; }

        public void Construct(InGamePentagramController inGamePentagramController)
        {
            _inGamePentagramController = inGamePentagramController;
            StartNewRound();
        }
        
        public void StartNewRound()
        {
            if (setups.Count == 0)
                return;
            var newSetup = setups[Random.Range(0, setups.Count)];
            _inGamePentagramController.SetSetup(newSetup);
            rightDemon = newSetup.demonSetupID;
            setups.Remove(newSetup);
        }
    }
}
