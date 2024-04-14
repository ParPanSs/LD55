using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace LudumDare55
{
    public class TimerModel
    {
        private float _timerTime;

        public TimerModel(float timerTime)
        {
            _timerTime = timerTime;
        }

        public string GetStringTime()
        {
            var minutes = Mathf.FloorToInt(_timerTime / 60f);
            var seconds = Mathf.FloorToInt(_timerTime % 60f);
            var displayTime = $"{minutes:00}{seconds:00}";
        
            return displayTime;
        }

        public float GetFloatTime()
        {
            return _timerTime;
        }

        public void DecrementTime(float step)
        {
            _timerTime = Mathf.Max(0, _timerTime - step);
        }
    }
}
