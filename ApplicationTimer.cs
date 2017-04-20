using System;
using System.Threading;

namespace InteractiveOfficeClient
{
    public partial class ApplicationTimer
    {

        public void ChangeState(AppState newAppState)
        {

            switch (newAppState)
            {
                case AppState.Working:
                case AppState.Break:
                    ResetTimer();
                    break;
                case AppState.NotifyingBreak:
                    _app.SetState(AppState.NotifyingBreak);
                    break;
                case AppState.NotifyingWork:
                    _app.SetState(AppState.NotifyingWork);
                    break;
            }
        }

        private void ResetTimer()
        {
            if (_app.IsWorking)
            {
                TimeLeft = INTERVAL_25_MIN_AS_SECONDS;
            }
            else
            {
                TimeLeft = INTERVAL_5_MIN_AS_SECONDS;
            }
        }

        private TimeSpan TimeSpanTickInterval = TimeSpan.FromSeconds(1);

#if DEBUG
        private static readonly int INTERVAL_MINUTE = 1;
#else
        private static readonly int INTERVAL_MINUTE = 60;
#endif

        private static readonly int INTERVAL_5_MIN_AS_SECONDS = 5 * INTERVAL_MINUTE;
        private static readonly int INTERVAL_25_MIN_AS_SECONDS = 5 * INTERVAL_5_MIN_AS_SECONDS;

        private int TimeLeft = 0;
        private readonly InteractiveOfficeClient _app;


        public ApplicationTimer(InteractiveOfficeClient app)
        {
            _app = app;
            new System.Threading.Timer(new TimerCallback(OnTimerCallback), AppState.Paused, TimeSpan.Zero,
                TimeSpanTickInterval);
        }

        private void OnTimerCallback(object state)
        {
            if (_app.IsNotifying)
            {
                return;
            }

            TimeLeft = TimeLeft - 1;

            if (TimeLeft <= 0)
            {
                _app.Show();
                TimeLeft = 0;
                if (_app.IsWorking)
                {
                    ChangeState(AppState.NotifyingBreak);
                }
                else
                {
                    ChangeState(AppState.NotifyingWork);
                }
            }
            _app.TimeLeft = TimeLeft;
        }
    }
}