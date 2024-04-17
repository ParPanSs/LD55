using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare55
{
    public class RoundStarter
    {
        public string rightDemon { get; private set; }
        public int setupsCount { get; private set; }
        public bool roundIsInProgress { get; private set; }

        private List<CreateScriptableObjectOfSetup> _setups;
        private InGamePentagramController _inGamePentagramController;
        private Ejector _ejector;

        public void Construct(InGamePentagramController inGamePentagramController, List<CreateScriptableObjectOfSetup> setups)
        {
            _setups = setups;
            _inGamePentagramController = inGamePentagramController;
            
            _ejector = new GameObject().AddComponent<Ejector>();
            StartNewRound(2);
        }
        
        public void StartNewRound(float delay)
        {
            _ejector.StartCoroutine(StartNewRoundRoutine(delay));
        }

        private IEnumerator StartNewRoundRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            var newSetup = _setups[Random.Range(0, _setups.Count)];
            _inGamePentagramController.SetSetup(newSetup);
            rightDemon = newSetup.demonSetupId;
            _setups.Remove(newSetup);
            SetRoundIsInProgress();
            setupsCount = _setups.Count;
        }

        public void SetRoundIsInProgress()
        {
            roundIsInProgress = !roundIsInProgress;
        }
    }
}
