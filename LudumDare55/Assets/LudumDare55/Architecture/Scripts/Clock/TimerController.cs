using System.Collections;
using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class TimerController
    {
        [SerializeField] private TimerView timerView;
        private TimerModel _timerModel;
        
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
                
                yield break;
            }
        }

        public void PunishmentDecrementTime(float time)
        {
            _timerModel.DecrementTime(time);
        }
    }
}
