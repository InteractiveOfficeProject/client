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

            new MainWindow();

            Application.Run ();
        }

    }

}