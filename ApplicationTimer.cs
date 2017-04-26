using System;
using System.Threading;

namespace InteractiveOfficeClient
{
    public class ApplicationTimer
    {
        public void ChangeState(AppState state)
        {
            switch (state)
            {
                case AppState.Working:
                case AppState.Break:
                    ResetTimer();
                    break;
            }
        }

        private void ResetTimer()
        {
            if (_app.IsWorking)
            {
                _timeLeft = Interval25MinAsSeconds;
            }
            else
            {
                _timeLeft = Interval5MinAsSeconds;
            }
        }

        private static readonly TimeSpan TimeSpanTickInterval = TimeSpan.FromSeconds(1);

#if DEBUG
        private static readonly double IntervalMinute = 0.3;
#else
        private static readonly double IntervalMinute = 60.0;
#endif

        private static readonly int Interval5MinAsSeconds = (int) (5 * IntervalMinute);
        private static readonly int Interval25MinAsSeconds = 5 * Interval5MinAsSeconds;

        private int _timeLeft = 0;
        private readonly InteractiveOfficeClient _app;


        public ApplicationTimer(InteractiveOfficeClient app)
        {
            _app = app;
            new System.Threading.Timer(new TimerCallback(OnTimerCallback), AppState.Paused, TimeSpan.Zero,
                TimeSpanTickInterval);
        }

        private void OnTimerCallback(object state)
        {
            if (_app.IsPaused || _app.IsNotifying)
            {
                return;
            }

            _timeLeft = _timeLeft - 1;

            if (_timeLeft <= 0)
            {
                _app.Show();
                _timeLeft = 0;
                _app.TriggerNotification();
            }
            _app.TimeLeft = _timeLeft;
        }
    }
}