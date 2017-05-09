using System;
using Gtk;

namespace InteractiveOfficeClient.Windows
{
    public class BreakNotificationWindow : Gtk.Window
    {
        private readonly InteractiveOfficeClient _app;

        private readonly Label _label = new Label("It is time for you to take a break.");
        private readonly Button _snoozeButton = new Button("Snooze");
        private readonly Button _continueButton = new Button("Ok");
        private readonly Grid _grid = new Grid();

        public BreakNotificationWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Break Time")
        {
            this._app = interactiveOfficeClient;

            Add(_grid);
            _grid.Attach(_label, 0, 0, 1, 2);
            _grid.Attach(_continueButton, 1, 0, 1, 1);
            _grid.Attach(_snoozeButton, 1, 1, 1, 1);

            _continueButton.Clicked += delegate { ContinueButtonClicked(); };
            _snoozeButton.Clicked += delegate { SnoozeButtonClicked(); };
            _snoozeButton.Sensitive = false;
        }

        private void SnoozeButtonClicked()
        {
            Console.WriteLine("snooze");
        }

        private void ContinueButtonClicked()
        {
            new ActivitySelectionWindow(_app).ShowAll();
            Close();
        }

    }
}