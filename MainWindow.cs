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
            ShowAll ();
        }

    }
}