using System;
using System.Threading;

namespace InteractiveOfficeClient
{
    public partial class ApplicationTimer
    {
        private readonly MainWindow Context;

        private bool _isWorking;

        public bool IsWorking => _appState == AppState.Working;

        private AppState _appState = AppState.Paused;

        public void ChangeState(AppState newAppState)
        {
            _appState = newAppState;

            switch (_appState)
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
            if (IsWorking)
            {
                TimeLeft = INTERVAL_25_MIN_AS_SECONDS;
            }
            else
            {
                TimeLeft = INTERVAL_5_MIN_AS_SECONDS;
            }
        }

        private bool IsReceivingTicks => _appState == AppState.Break || _appState == AppState.Working;

        private TimeSpan TimeSpanTickInterval = TimeSpan.FromSeconds(1);

#if DEBUG
        private static readonly int INTERVAL_MINUTE = 1;
#else
        private static readonly int INTERVAL_MINUTE = 60;
#endif

        private static readonly int INTERVAL_5_MIN_AS_SECONDS = 5 * INTERVAL_MINUTE;
        private static readonly int INTERVAL_25_MIN_AS_SECONDS = 5 * INTERVAL_5_MIN_AS_SECONDS;

        private int TimeLeft = 0;


        public ApplicationTimer(MainWindow Context)
        {
            this.Context = Context;
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