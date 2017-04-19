using System;
using System.Threading;

namespace InteractiveOfficeClient
{
    public class ApplicationTimer
    {
        private readonly MainWindow Context;

        private bool _isWorking;

        public bool IsWorking
        {
            get { return _isWorking; }
            set
            {
                _isWorking = value;
                if (_isWorking)
                    TimeLeft = INTERVAL_25_MIN_AS_SECONDS;
                else
                    TimeLeft = INTERVAL_5_MIN_AS_SECONDS;
                IsReceivingTicks = true;
            }
    }

        private bool IsReceivingTicks = false;

        private TimeSpan TimeSpanTickInterval = TimeSpan.FromSeconds(1);

        #if DEBUG
        private static readonly int INTERVAL_MINUTE = 1;
        #else
        private static readonly int INTERVAL_MINUTE = 60;
        #endif

        private static readonly int INTERVAL_5_MIN_AS_SECONDS = 5*INTERVAL_MINUTE;
        private static readonly int INTERVAL_25_MIN_AS_SECONDS = 5*INTERVAL_5_MIN_AS_SECONDS;

        private int TimeLeft = 0;


        public ApplicationTimer(MainWindow Context)
        {
            this.Context = Context;
            new System.Threading.Timer(new TimerCallback(OnTimerCallback), "", TimeSpan.Zero, TimeSpanTickInterval);
        }

        private void OnTimerCallback(object state)
        {
            if(!IsReceivingTicks){
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
                    Console.WriteLine("Show Activities");
                    IsReceivingTicks = false;
                }
            }
            Context.TimeLeft = TimeLeft;
        }

    }
}