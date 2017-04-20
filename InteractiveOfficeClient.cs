using System.Dynamic;
using System.IO;
using System.Reflection;
using Gdk;
using GLib;

namespace InteractiveOfficeClient
{
    using Gtk;

    public class InteractiveOfficeClient
    {
        private static InteractiveOfficeClient Instance = new InteractiveOfficeClient();
        private ApplicationTimer _applicationTimer;
        private MainWindow mainWindow;

        public bool IsWorking => _appState == AppState.Working;
        public bool IsNotifying => _appState == AppState.Break || _appState == AppState.Working;

        private int _timeLeft;

        public int TimeLeft
        {
            get { return _timeLeft; }
            set
            {
                _timeLeft = value;
                mainWindow.UpdateUi();
            }
        }


        private AppState _appState = AppState.Paused;

        private InteractiveOfficeClient()
        {
        }

        static void Main()
        {
            Instance.Run();
        }

        public void Run()
        {
            Application.Init();

            mainWindow = new MainWindow(this);
            _applicationTimer = new ApplicationTimer(this);
            new IopTrayIcon(this);


            Application.Run();
        }

        public void SetState(AppState newState)
        {
            _applicationTimer.ChangeState(newState);
        }

        public void ToggleAppVisibility()
        {
            mainWindow.Visible = !mainWindow.Visible;
        }

        public void Show()
        {
            mainWindow.Deiconify();
            mainWindow.Visible = true;
        }
    }
}