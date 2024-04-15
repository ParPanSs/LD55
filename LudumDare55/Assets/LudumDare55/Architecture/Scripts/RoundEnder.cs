namespace LudumDare55
{
    [System.Serializable]
    public class RoundEnder
    {
        private InGamePentagramController _inGamePentagramController;
        private RoundStarter _roundStarter;
        private TimerController _timerController;
        private SceneTransition _sceneTransition;

        public void Construct(RoundStarter roundStarter, InGamePentagramController inGamePentagramController,
            TimerController timerController, SceneTransition sceneTransition)
        {
            _roundStarter = roundStarter;
            _inGamePentagramController = inGamePentagramController;
            _timerController = timerController;
            _sceneTransition = sceneTransition;
        }

        public void CompareId(string currentSelectedDemonID)
        {
            if (currentSelectedDemonID == _roundStarter.rightDemon) RoundEnded();
            else _timerController.PunishmentDecrementTime();
        }

        private void RoundEnded()
        {
            if (!_roundStarter.roundIsInProgress) return;
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