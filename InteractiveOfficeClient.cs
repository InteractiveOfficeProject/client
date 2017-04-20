using System.Dynamic;
using System.IO;
using System.Reflection;
using Gdk;
using GLib;

namespace InteractiveOfficeClient
{
    using Gtk;
    public class InteractiveOfficeClient {
        private static InteractiveOfficeClient Instance = new InteractiveOfficeClient();
        private readonly ApplicationTimer _applicationTimer;
        private readonly MainWindow mainWindow;

        public bool IsWorking => _appState == AppState.Working;
        public bool IsNotifying => _appState == AppState.Break || _appState == AppState.Working;


        private AppState _appState = AppState.Paused;

        private InteractiveOfficeClient()
        {
            mainWindow = new MainWindow(this);
            _applicationTimer = new ApplicationTimer(this);
            new IopTrayIcon(this);
        }
        static void Main()
        {
            InteractiveOfficeClient.Instance.Run();
        }

        public void Run()
        {
            Application.Init();

            Application.Run ();
        }

        public void SetState(AppState newState)
        {
            _applicationTimer.ChangeState(newState);
        }

        public void ToggleAppVisibility()
        {
            mainWindow.Visible = !mainWindow.Visible;
        }
    }

}