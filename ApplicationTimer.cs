using System;
using System.Threading;

namespace InteractiveOfficeClient
{
    public partial class ApplicationTimer
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
            if (_app.IsPaused || _app.IsNotifying)
            {
                return;
            }

            TimeLeft = TimeLeft - 1;

            if (TimeLeft <= 0)
            {
                _app.Show();
                TimeLeft = 0;
                _app.TriggerNotification();
            }
            _app.TimeLeft = TimeLeft;
        }
    }
}