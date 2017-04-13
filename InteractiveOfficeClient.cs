using System.IO;
using System.Reflection;
using Gdk;
using GLib;

namespace InteractiveOfficeClient
{
    using Gtk;
    public class InteractiveOfficeClient {
        static void Main() {
            Application.Init ();

            var mainWindow = new MainWindow();
            var trayIcon = new IopTrayIcon(mainWindow);
            Application.Run ();
        }

    }

}