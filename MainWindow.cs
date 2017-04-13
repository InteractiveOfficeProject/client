using System;
using Gdk;
using Gtk;

namespace InteractiveOfficeClient
{
    public class MainWindow : Gtk.Window
    {

        public MainWindow() : base("Interactive Office Project")
        {
            DeleteEvent += delegate  { Visible = false; };
            CreateTrayIcon();
            ShowAll ();
        }

        private void CreateTrayIcon()
        {
            var trayIcon = new IopTrayIcon(this);
            trayIcon.Visible = true;
        }

    }
}