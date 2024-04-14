using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare55
{
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private List<CreateScriptableObjectOfSetup> setups;
        private TimerController _timerController;
        private InGamePentagramController _inGamePentagramController;
        private readonly RoundStartEvent _roundStartEvent = new();

        public void Construct(InGamePentagramController inGamePentagramController, TimerController timerController)
        {
            _inGamePentagramController = inGamePentagramController;
            _roundStartEvent.OnRoundStarted += _inGamePentagramController.SetSetup;

            _timerController = timerController;
            _roundStartEvent.OnRoundStarted += _timerController.StartTimer;
            
                // TODO: REMOVE THIS SHIT
            Invoke(nameof(StartNewRound), 5f);
        }
        
        private void StartNewRound()
        {
            var newSetup = setups[Random.Range(0, setups.Count)];
            _roundStartEvent.InvokeEvent(newSetup);
        }

        private void OnDestroy()
        {
            if (_inGamePentagramController != null)
                _roundStartEvent.OnRoundStarted -= _inGamePentagramController.SetSetup;
            if (_timerController != null)
                _roundStartEvent.OnRoundStarted -= _timerController.StartTimer;
        }
    }
}
