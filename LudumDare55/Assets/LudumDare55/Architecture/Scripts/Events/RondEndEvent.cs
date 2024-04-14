using System;

namespace LudumDare55
{
    public class RoundEndEvent
    {
        public event EventHandler OnRoundEnded;

        public void InvokeEvent()
        {
            OnRoundEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}