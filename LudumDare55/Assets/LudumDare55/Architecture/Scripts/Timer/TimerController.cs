using System.Collections;
using UnityEngine;

namespace LudumDare55
{
    public class TimerController
    {
        private TimerView _timerView;
        private TimerModel _timerModel;
        private RoundEnder _roundEnder;
        private const float PunishmentTime = 10f;

        public void Construct(RoundEnder roundEnder, TimerView timerView)
        {
            _timerView = timerView;
            _roundEnder = roundEnder;
        }
        
        public IEnumerator DecrementTimeCoroutine(float time)
        {
            _timerModel = new TimerModel(time);
            _timerView.DisplayTime(_timerModel.GetStringTime());
            
            while (_timerModel.GetFloatTime() > 0)
            {
                if (_timerModel.GetFloatTime() == 10f)
                {
                    _timerView.SetRageAnimation();
                }
                yield return new WaitForSecondsRealtime(1f);
                if (Time.timeScale == 0) { continue; }

                _timerModel.DecrementTime(1);
                _timerView.DisplayTime(_timerModel.GetStringTime());

                if (_timerModel.GetFloatTime() != 0) { continue; }
                _roundEnder.EndDay();
                yield break;
            }
        }

        public void PunishmentDecrementTime()
        {
            _timerModel.DecrementTime(PunishmentTime);
            _timerView.DisplayTime(_timerModel.GetStringTime());
        }
    }
}
