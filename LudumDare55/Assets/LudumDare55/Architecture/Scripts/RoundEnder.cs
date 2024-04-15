using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class RoundEnder
    {
        private InGamePentagramController _inGamePentagramController;
        private RoundStarter _roundStarter;
        private TimerController _timerController;
        private SceneTransition _sceneTransition;
        private AudioSource _roundSuccessAudioSource;

        public void Construct(RoundStarter roundStarter, InGamePentagramController inGamePentagramController,
            TimerController timerController, SceneTransition sceneTransition, AudioSource roundSuccessAudioSource)
        {
            _roundStarter = roundStarter;
            _inGamePentagramController = inGamePentagramController;
            _timerController = timerController;
            _sceneTransition = sceneTransition;
            _roundSuccessAudioSource = roundSuccessAudioSource;
        }

        public void CompareId(string currentSelectedDemonID)
        {
            if (currentSelectedDemonID == _roundStarter.rightDemon) RoundEnded();
            else _timerController.PunishmentDecrementTime();
        }

        private void RoundEnded()
        {
            if (!_roundStarter.roundIsInProgress) return;
         
            _roundSuccessAudioSource.Play();
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
            _sceneTransition.SetFader();
        }
    }
}