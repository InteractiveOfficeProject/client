using Gdk;
using Gtk;
using Window = Gtk.Window;

namespace InteractiveOfficeClient
{
    public class IopTrayIcon : Gtk.StatusIcon
    {
        public IopTrayIcon(Gtk.Window window) : base(Pixbuf.LoadFromResource("InteractiveOfficeClient.Resources.app_icon.png"))
        {
            Activate += delegate { window.Visible = !window.Visible; };
            PopupMenu += OnTrayIconPopup;
            TooltipText = "Hello World Icon";
            Visible = true;
        }

        private void OnTrayIconPopup (object o, PopupMenuArgs popupMenuArgs) {
            Menu popupMenu = new Menu();
            ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
            Gtk.Image appimg = new Gtk.Image(Gtk.Stock.Quit, IconSize.Menu);
            menuItemQuit.Image = appimg;
            popupMenu.Add(menuItemQuit);
            // Quit the application when quit has been clicked.
            menuItemQuit.Activated += delegate { Application.Quit(); };
            popupMenu.ShowAll();
            popupMenu.Popup();
        }

    }
}