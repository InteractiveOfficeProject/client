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
        private readonly ApplicationTimer _applicationTimer;


        public MainWindow() : base("Interactive Office Project")
        {
            Add(Grid);
            Grid.Attach(LabelTimeLeft, 0, 0, 1, 1);
            Grid.AttachNextTo(BtnStartWorking, LabelTimeLeft, PositionType.Bottom, 1, 1);
            Grid.AttachNextTo(BtnStartBreak, BtnStartWorking, PositionType.Bottom, 1, 1);

            BtnStartWorking.Clicked += delegate { SetWorkingState(true); };
            BtnStartBreak.Clicked += delegate { SetWorkingState(false); };

            _applicationTimer = new ApplicationTimer(this);

            ShowAll();
        }

        public int TimeLeft
        {
            set
            {
                if (value <= 0)
                {
                    LabelTimeLeft.Text = "";
                }
                else
                {
                    LabelTimeLeft.Text = $"{value}s";
                }
            }
        }

        protected override bool OnDeleteEvent(Event evnt)
        {
            Iconify();
            Visible = false;
            return true;
        }

        private void SetWorkingState(bool newState)
        {
            _applicationTimer.IsWorking = newState;
            UpdateUi();
            Visible = false;
            Iconify();
        }

        private void UpdateUi()
        {
            BtnStartWorking.Sensitive = !_applicationTimer.IsWorking;
            BtnStartBreak.Sensitive = _applicationTimer.IsWorking;
        }

        protected override bool OnVisibilityNotifyEvent(EventVisibility evnt)
        {
            var baseResult = base.OnVisibilityNotifyEvent(evnt);
            UpdateUi();
            return baseResult;
        }
    }
}