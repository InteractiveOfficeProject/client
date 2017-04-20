using Gdk;
using Gtk;
using Window = Gtk.Window;

namespace InteractiveOfficeClient
{
    public class IopTrayIcon : Gtk.StatusIcon
    {
        private readonly Menu _popupMenu;

        public IopTrayIcon(InteractiveOfficeClient app) : base(
            Pixbuf.LoadFromResource("InteractiveOfficeClient.Resources.app_icon.png"))
        {
            Activate += delegate { app.ToggleAppVisibility(); };
            PopupMenu += OnTrayIconPopup;
            TooltipText = "Interactive Office";
            Visible = true;

            _popupMenu = new Menu();

            var menuItemStartWork = AddImageMenuItem("Start Work", Gtk.Stock.MediaPlay);
            menuItemStartWork.Activated += delegate
            {
                app.State = AppState.Working;
            };

            var menuItemStartPause = AddImageMenuItem("Start Break", Gtk.Stock.MediaPause);
            menuItemStartPause.Activated += delegate
            {
                app.State = AppState.Paused;
            };

            var menuItemQuit = AddImageMenuItem("Quit", Gtk.Stock.Quit);
            menuItemQuit.Activated += delegate { Application.Quit(); };
        }

        private void OnTrayIconPopup(object o, PopupMenuArgs popupMenuArgs)
        {
            _popupMenu.ShowAll();
            _popupMenu.Popup();
        }

        private  ImageMenuItem AddImageMenuItem(string label, string quit)
        {
            ImageMenuItem menuItem = new ImageMenuItem(label);
            menuItem.Image = new Gtk.Image(quit, IconSize.Menu);
            _popupMenu.Add(menuItem);
            return menuItem;
        }
    }
}