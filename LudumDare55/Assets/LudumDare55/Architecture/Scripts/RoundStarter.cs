using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare55
{
    [System.Serializable]
    public class RoundStarter
    {
        [SerializeField] private List<CreateScriptableObjectOfSetup> setups;
        private TimerController _timerController;
        private InGamePentagramController _inGamePentagramController;

        public void Construct(InGamePentagramController inGamePentagramController, TimerController timerController)
        {
            _inGamePentagramController = inGamePentagramController;

            _timerController = timerController;
            
                // TODO: REMOVE THIS SHIT
            StartNewRound();
        }
        
        public void StartNewRound()
        {
            var newSetup = setups[Random.Range(0, setups.Count)];
            _inGamePentagramController.SetSetup(newSetup);
            _timerController.StartTimer(newSetup);
        }
    }
}
