namespace LudumDare55
{
    [System.Serializable]
    public class RoundEnder
    {
        private RoundStarter _roundStarter;
        private TimerController _timerController;
        private InGamePentagramController _inGamePentagramController;

        public void Construct(RoundStarter roundStarter, InGamePentagramController inGamePentagramController)
        {
            _roundStarter = roundStarter;
            _inGamePentagramController = inGamePentagramController;
        }
        public void CompareId(string currentSelectedDemonID)
        {
            if (currentSelectedDemonID == _roundStarter.rightDemon) RoundEnded();
            else _timerController.PunishmentDecrementTime();
        }
        
        private void RoundEnded()
        {
            _inGamePentagramController.ClearSetup();
            _roundStarter.StartNewRound();
        }
        
    }
}