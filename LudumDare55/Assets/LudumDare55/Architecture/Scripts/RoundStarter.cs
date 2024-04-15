using System.Collections;
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
        private Ejector _ejector;
        
        public string rightDemon { get; private set; }
        public int setupsCount { get; private set; }

        public void Construct(InGamePentagramController inGamePentagramController)
        {
            _ejector = new GameObject().AddComponent<Ejector>();
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
            
            var newSetup = setups[Random.Range(0, setups.Count)];
            _inGamePentagramController.SetSetup(newSetup);
            rightDemon = newSetup.demonSetupID;
            setups.Remove(newSetup);
            setupsCount = setups.Count;
        }
    }
}
