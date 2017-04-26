using System;
using System.Threading;
using Gdk;
using Gtk;

namespace InteractiveOfficeClient
{
    public class MainWindow : Gtk.Window
    {
        private readonly Grid _grid = new Grid();
        private readonly Button _btnStartWorking = new Button("Start Working");
        private readonly Button _btnStartBreak = new Button("Start Break");
        private readonly Label _labelTimeLeft = new Label("");
        private readonly InteractiveOfficeClient _app;


        public MainWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Interactive Office Project")
        {
            _app = interactiveOfficeClient;
            Add(_grid);
            _grid.Attach(_labelTimeLeft, 0, 0, 1, 1);
            _grid.AttachNextTo(_btnStartWorking, _labelTimeLeft, PositionType.Bottom, 1, 1);
            _grid.AttachNextTo(_btnStartBreak, _btnStartWorking, PositionType.Bottom, 1, 1);

            _btnStartWorking.Clicked += delegate
            {
                _app.State = AppState.Working;
                Close();
            };
            _btnStartBreak.Clicked += delegate
            {
                _app.State = AppState.Break;
                Close();
            };

            ShowAll();
        }

        protected override bool OnDeleteEvent(Event evnt)
        {
            Iconify();
            Visible = false;
            return true;
        }

        private void SetState(AppState newState)
        {
            Visible = false;
            Iconify();
        }

        public void UpdateUi()
        {
            if (_app.TimeLeft <= 0)
            {
                _labelTimeLeft.Text = "";
            }
            else
            {
                _labelTimeLeft.Text = $"{_app.TimeLeft}s";
            }
            _btnStartWorking.Sensitive = !_app.IsWorking;
            _btnStartBreak.Sensitive = _app.IsWorking;
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