using System;
using System.Threading;
using Gdk;
using Gtk;

namespace InteractiveOfficeClient
{
    public class MainWindow : Gtk.Window
    {
        private readonly Grid Grid = new Grid();
        private readonly Button BtnStartWorking = new Button("Start Working");
        private readonly Button BtnStartBreak = new Button("Start Break");
        private readonly Label LabelTimeLeft = new Label("");


        private bool IsWorking = false;

        private enum TimerState {Created, Running, Paused};

        private static readonly int INTERVAL_1_SECOND_AS_MILLIS = 1000;
        private static readonly int INTERVAL_5_MIN_AS_SECONDS = 5*60;
        private static readonly int INTERVAL_25_MIN_AS_SECONDS = 5*INTERVAL_5_MIN_AS_SECONDS;

        private int TimeLeft = 0;

        public MainWindow() : base("Interactive Office Project")
        {
            Add(Grid);
            Grid.Attach(LabelTimeLeft, 0, 0, 1, 1);
            Grid.AttachNextTo(BtnStartWorking, LabelTimeLeft, PositionType.Bottom, 1, 1);
            Grid.AttachNextTo(BtnStartBreak, BtnStartWorking, PositionType.Bottom, 1, 1);

            DeleteEvent += delegate { Iconify(); };

            BtnStartWorking.Clicked += delegate {
                SetWorkingState(true);
            };
            BtnStartBreak.Clicked += delegate { SetWorkingState(false); };

            ShowAll();

            new System.Threading.Timer(new TimerCallback(OnTimerCallback), "", TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void OnTimerCallback(object state)
        {
            TimeLeft = TimeLeft - 1;
            LabelTimeLeft.Text = $"Time Left: {TimeLeft}s";

            if (TimeLeft <= 0)
            {
                Deiconify();
                TimeLeft = 0;
                LabelTimeLeft.Text = $"";
            }

        }

        private void SetWorkingState(bool newState)
        {
            IsWorking = newState;

            if (IsWorking)
                TimeLeft = INTERVAL_25_MIN_AS_SECONDS;
            else
                TimeLeft = INTERVAL_5_MIN_AS_SECONDS;

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
