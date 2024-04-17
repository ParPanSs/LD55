using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace LudumDare55
{
    [System.Serializable]
    public class RoundEnder
    {
        private InGamePentagramController _inGamePentagramController;
        private RoundStarter _roundStarter;
        private TimerController _timerController;
        private SceneTransition _sceneTransition;
        private PlayableDirector _roundSuccessTimeline; 
        private TextMeshPro _roundsLeftText;
        private Ejector _ejector;

        private int score;

        public void Construct(RoundStarter roundStarter,
            InGamePentagramController inGamePentagramController,
            TimerController timerController,
            SceneTransition sceneTransition,
            PlayableDirector roundSuccessTimeline,
            TextMeshPro roundsLeftText)
        {
            _roundStarter = roundStarter;
            _inGamePentagramController = inGamePentagramController;
            _timerController = timerController;
            _sceneTransition = sceneTransition;
            _roundSuccessTimeline = roundSuccessTimeline;
            _roundsLeftText = roundsLeftText;
            
            _ejector = new GameObject().AddComponent<Ejector>();
        }

        public void CompareId(string currentSelectedDemonID)
        {
            if (currentSelectedDemonID == _roundStarter.rightDemon) RoundEnded();
            else _timerController.PunishmentDecrementTime();
        }

        // TODO: make private
        public void RoundEnded()
        {
            if (!_roundStarter.roundIsInProgress) return;
         
            score++;
            PlayerPrefs.SetInt("PlayerScore", score);
            PlayerPrefs.Save();
            
            _roundSuccessTimeline.Play();
            _inGamePentagramController.ClearSetup();
            _roundsLeftText.text = _roundStarter.setupsCount.ToString();
            
            if (_roundStarter.setupsCount > 0) { _roundStarter.StartNewRound(5f); }
            else { EndDay(4f); }
            
            _roundStarter.SetRoundIsInProgress();
        }

        public void EndDay(float delay)
        {
            _ejector.StartCoroutine(EndDayRoutine(delay));
        }
        
        private IEnumerator EndDayRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            PlayerPrefs.SetInt("PlayerScore", score);
            PlayerPrefs.Save();
            _sceneTransition.SetFader();
        }
    }
}