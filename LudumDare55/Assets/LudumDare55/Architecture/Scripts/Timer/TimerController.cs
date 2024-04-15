using System.Collections;
using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class TimerController
    {
        [SerializeField] private TimerView timerView;
        private TimerModel _timerModel;
        private RoundEnder _roundEnder;
        private const float PunishmentTime = 10f;

        public void Construct(RoundEnder roundEnder)
        {
            _roundEnder = roundEnder;
        }
        public IEnumerator DecrementTimeCoroutine(float time)
        {
            _timerModel = new TimerModel(time);
            timerView.DisplayTime(_timerModel.GetStringTime());
            
            while (_timerModel.GetFloatTime() > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                if (Time.timeScale == 0) { continue; }

                _timerModel.DecrementTime(1);
                timerView.DisplayTime(_timerModel.GetStringTime());

                if (_timerModel.GetFloatTime() != 0) { continue; }
                _roundEnder.EndDay();
                yield break;
            }
        }

        public void PunishmentDecrementTime()
        {
            _timerModel.DecrementTime(PunishmentTime);
            timerView.DisplayTime(_timerModel.GetStringTime());
        }
    }
}
