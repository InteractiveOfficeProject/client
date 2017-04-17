using System;
using System.Threading;
using Gdk;
using Gtk;

namespace InteractiveOfficeClient
{
    public class MainWindow : Gtk.Window
    {
        private readonly Button BtnStartWorking = new Button("Start Working");
        private readonly Button BtnStartBreak = new Button("Start Break");
        private readonly Grid Grid = new Grid();
        private bool IsWorking = false;

        private enum TimerState {Created, Running, Paused};

        private static readonly int INTERVAL_1_SECOND_AS_MILLIS = 1000;
        private static readonly int INTERVAL_5_MIN_AS_SECONDS = 5*60;
        private static readonly int INTERVAL_25_MIN_AS_SECONDS = 5*INTERVAL_5_MIN_AS_SECONDS;

        private int TimeLeft = 0;
        private TimerCallback Callback;
        private Timer Timer;

        public MainWindow() : base("Interactive Office Project")
        {
            Add(Grid);
            Grid.Attach(BtnStartWorking, 0, 0, 1, 1);
            Grid.Attach(BtnStartBreak, 0, 1, 1, 1);
            Grid.AttachNextTo(BtnStartBreak, BtnStartWorking, PositionType.Bottom, 1, 1);

            DeleteEvent += delegate { Visible = false; };

            BtnStartWorking.Clicked += delegate {
                SetWorkingState(true);
            };
            BtnStartBreak.Clicked += delegate { SetWorkingState(false); };

            ShowAll();

            Callback = new TimerCallback(OnTimerCallback);
        }

        private void OnTimerCallback(object state)
        {
            TimeLeft = TimeLeft - 1;
            if (TimeLeft <= 0)
            {
                Visible = true;
            }
        }

        private void SetWorkingState(bool newState)
        {
            IsWorking = newState;

            if (IsWorking)
                TimeLeft = INTERVAL_25_MIN_AS_SECONDS;
            else
                TimeLeft = INTERVAL_5_MIN_AS_SECONDS;

            Timer = new System.Threading.Timer(Callback, "", int.MaxValue, INTERVAL_1_SECOND_AS_MILLIS);

            UpdateUi();
            Visible = false;
        }

        private void UpdateUi()
        {
            BtnStartWorking.Sensitive = !IsWorking;
            BtnStartBreak.Sensitive = IsWorking;
        }

        protected override bool OnVisibilityNotifyEvent(EventVisibility evnt)
        {
            var baseResult = base.OnVisibilityNotifyEvent(evnt);
            UpdateUi();
            return baseResult;
        }

    }
}