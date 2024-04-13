using System;

namespace LudumDare55
{
    public class BookmarkEvent
    {
        public event EventHandler<string> OnBookmarkPressed;

        public void InvokeEvent(string demonID)
        {
            OnBookmarkPressed?.Invoke(this, demonID);
        }
    }
}