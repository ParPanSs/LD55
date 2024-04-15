using System.Collections;
using System.Collections.Generic;
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
            _ejector = new GameObject().AddComponent<Ejector>();
            _setups = setups;
            _inGamePentagramController = inGamePentagramController;
            StartNewRound();
        }
        
        public void StartNewRound()
        {
            _ejector.StartCoroutine(StartNewRoundRoutine(7f));
        }

        private IEnumerator StartNewRoundRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            var newSetup = _setups[Random.Range(0, _setups.Count)];
            _inGamePentagramController.SetSetup(newSetup);
            rightDemon = newSetup.demonSetupID;
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
