using System;
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


        public MainWindow() : base("Interactive Office Project")
        {
            DeleteEvent += delegate { Visible = false; };
            Add(Grid);

            Grid.Attach(BtnStartWorking, 0, 0, 1, 1);
            Grid.Attach(BtnStartBreak, 0, 1, 1, 1);
            Grid.AttachNextTo(BtnStartBreak, BtnStartWorking, PositionType.Bottom, 1, 1);

            BtnStartWorking.Clicked += delegate { SetWorkingState(true); };

            BtnStartBreak.Clicked += delegate { SetWorkingState(false); };

            ShowAll();
        }

        private void SetWorkingState(bool newState)
        {
            IsWorking = newState;
            UpdateUi();
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