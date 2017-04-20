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
        private readonly InteractiveOfficeClient _app;


        public MainWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Interactive Office Project")
        {
            this._app = interactiveOfficeClient;
            Add(Grid);
            Grid.Attach(LabelTimeLeft, 0, 0, 1, 1);
            Grid.AttachNextTo(BtnStartWorking, LabelTimeLeft, PositionType.Bottom, 1, 1);
            Grid.AttachNextTo(BtnStartBreak, BtnStartWorking, PositionType.Bottom, 1, 1);

            BtnStartWorking.Clicked += delegate { SetWorkingState(AppState.Working); };
            BtnStartBreak.Clicked += delegate { SetWorkingState(AppState.Break); };

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

        private void SetWorkingState(AppState newState)
        {
            _app.SetState(newState);
            UpdateUi();
            Visible = false;
            Iconify();
        }

        public void UpdateUi()
        {
            BtnStartWorking.Sensitive = !_app.IsWorking;
            BtnStartBreak.Sensitive = _app.IsWorking;
        }

        protected override bool OnVisibilityNotifyEvent(EventVisibility evnt)
        {
            var baseResult = base.OnVisibilityNotifyEvent(evnt);
            UpdateUi();
            return baseResult;
        }

        public void NotifyBreak()
        {
            Console.WriteLine("NotifyBreak");
        }

        public void NotifyWork()
        {
            Console.WriteLine("NotifyWork");
        }
    }
}