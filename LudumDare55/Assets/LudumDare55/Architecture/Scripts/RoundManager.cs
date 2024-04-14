using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare55
{
    public class RoundManager : MonoBehaviour
    {
        private const float RoundTime = 30f;
        
        [SerializeField] private List<CreateScriptableObjectOfSetup> setups;
        
        private InGamePentagramController _inGamePentagramController;
        private readonly RoundStartEvent _roundStartEvent = new();

        public void Construct(InGamePentagramController inGamePentagramController)
        {
            _inGamePentagramController = inGamePentagramController;
            _roundStartEvent.OnRoundStarted += _inGamePentagramController.SetSetup; 
            
                // TODO: REMOVE THIS SHIT
                StartNewRound();
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
        }
    }
}
