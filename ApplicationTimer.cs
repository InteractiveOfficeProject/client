using System;
using System.Threading;

namespace InteractiveOfficeClient
{
    public partial class ApplicationTimer
    {
        private readonly MainWindow Context;



        public void ChangeState(AppState newAppState)
        {

            switch (newAppState)
            {
                case AppState.Working:
                case AppState.Break:
                    ResetTimer();
                    break;
                case AppState.NotifyingBreak:
                    Context.NotifyBreak();
                    break;
                case AppState.NotifyingWork:
                    Context.NotifyWork();
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

        private bool IsReceivingTicks => !_app.IsNotifying;

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
            if (!IsReceivingTicks)
            {
                return;
            }

            TimeLeft = TimeLeft - 1;

            if (TimeLeft <= 0)
            {
                Context.Deiconify();
                Context.Visible = true;
                TimeLeft = 0;
                if (IsWorking)
                {
                    ChangeState(AppState.NotifyingBreak);
                }
                else
                {
                    ChangeState(AppState.NotifyingWork);
                }
            }
            Context.TimeLeft = TimeLeft;
        }
    }
}