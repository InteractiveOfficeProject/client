using System.IO;
using System.Reflection;
using Gdk;
using GLib;

namespace InteractiveOfficeClient
{
    using Gtk;
    public class HelloWorld {
        // The tray Icon
        private static StatusIcon trayIcon;
        // The Window
        private static Gtk.Window window;

        static string workingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        static void Main() {
            // Initialize GTK#
            Application.Init ();

            // Create a Window with title
            window = new Gtk.Window ("Hello World");

            // Attach to the Delete Event when the window has been closed.
            window.DeleteEvent += delegate  { window.Visible = !window.Visible; };

            // Creation of the Icon
            trayIcon = new StatusIcon(new Pixbuf(workingDirectory + "/Resources/app_icon.png"));
            trayIcon.Visible = true;

            // Show/Hide the window (even from the Panel/Taskbar) when the TrayIcon has been clicked.
            trayIcon.Activate += delegate { window.Visible = !window.Visible; };
            // Show a pop up menu when the icon has been right clicked.
            trayIcon.PopupMenu += OnTrayIconPopup;

            // A Tooltip for the Icon
            trayIcon.TooltipText = "Hello World Icon";

            // Show the main window and start the application.
            window.ShowAll ();
            Application.Run ();
        }

        // Create the popup menu, on right click.
        static void OnTrayIconPopup (object o, PopupMenuArgs popupMenuArgs) {
            Menu popupMenu = new Menu();
            ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
            Gtk.Image appimg = new Gtk.Image(Stock.Quit, IconSize.Menu);
            menuItemQuit.Image = appimg;
            popupMenu.Add(menuItemQuit);
            // Quit the application when quit has been clicked.
            menuItemQuit.Activated += delegate { Application.Quit(); };
            popupMenu.ShowAll();
            popupMenu.Popup();
        }
    }

}