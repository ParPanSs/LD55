using System;

namespace LudumDare55
{
    public class RoundStartEvent
    {
        public event EventHandler<CreateScriptableObjectOfSetup> OnRoundStarted;

        public void InvokeEvent(CreateScriptableObjectOfSetup setup)
        {
            OnRoundStarted?.Invoke(this, setup);
        }
    }
}