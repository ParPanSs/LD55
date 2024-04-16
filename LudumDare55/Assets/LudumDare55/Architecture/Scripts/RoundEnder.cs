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

        private int score;

        public void Construct(RoundStarter roundStarter, InGamePentagramController inGamePentagramController,
            TimerController timerController, SceneTransition sceneTransition, PlayableDirector roundSuccessTimeline)
        {
            _roundStarter = roundStarter;
            _inGamePentagramController = inGamePentagramController;
            _timerController = timerController;
            _sceneTransition = sceneTransition;
            _roundSuccessTimeline = roundSuccessTimeline;
        }

        public void CompareId(string currentSelectedDemonID)
        {
            if (currentSelectedDemonID == _roundStarter.rightDemon) RoundEnded();
            else _timerController.PunishmentDecrementTime();
        }

        private void RoundEnded()
        {
            if (!_roundStarter.roundIsInProgress) return;
         
            score++;
            PlayerPrefs.SetInt("PlayerScore", score);
            PlayerPrefs.Save();
            _roundSuccessTimeline.Play();
            if (_roundStarter.setupsCount > 0)
            {
                _inGamePentagramController.ClearSetup();
                _roundStarter.StartNewRound();
            }
            else
            {
                EndDay();
            }
            _roundStarter.SetRoundIsInProgress();
        }

        public void EndDay()
        {
            PlayerPrefs.SetInt("PlayerScore", score);
            PlayerPrefs.Save();
            _sceneTransition.SetFader();
        }
    }
}