using System.IO;
using System.Reflection;
using Gdk;
using GLib;

namespace InteractiveOfficeClient
{
    using Gtk;
    public class HelloWorld {
        // The Window
        private static Gtk.Window window;

        static string workingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        static void Main() {
            Application.Init ();

            new MainWindow();

            Application.Run ();
        }

    }

}