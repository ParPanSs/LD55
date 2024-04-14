using System.Threading.Tasks;
using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class TimerController
    {
        [SerializeField] private TimerView timerView;
        private TimerModel _timerModel;
        private readonly RoundEndEvent _roundEndEvent = new();
    
        public async void StartTimer(CreateScriptableObjectOfSetup setup)
        {
            _timerModel = new TimerModel(setup.SetupTime);
            timerView.DisplayTime(_timerModel.GetStringTime());
            
            await DecrementTimeAsync();
        }
        
        private async Task DecrementTimeAsync()
        {
            while (_timerModel.GetFloatTime() > 0)
            {
                await Task.Delay(1000);
                
                _timerModel.DecrementTime(1);
                timerView.DisplayTime(_timerModel.GetStringTime());

                if (_timerModel.GetFloatTime() != 0) continue;
                
                _roundEndEvent.InvokeEvent();
                return;
            }
        }

        public void PunishmentDecrementTime(float time)
        {
            _timerModel.DecrementTime(time);
        }
    }
}
