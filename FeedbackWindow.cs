using System;
using System.Threading.Tasks;
using Gtk;
using InteractiveOfficeClient.Models;

namespace InteractiveOfficeClient
{
    public class FeedbackWindow : Gtk.Window
    {
        private InteractiveOfficeClient _app;
        private readonly Grid _grid = new Grid();

        public FeedbackWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Work Time")
        {
            this._app = interactiveOfficeClient;
            Add(_grid);

            Button feedbackButton = new Button("Give Feedback");
            feedbackButton.Sensitive = false; // FIXME Enable Button after feedback url was added
            feedbackButton.Clicked += delegate { FeedbackButtonClicked(); };
            _grid.Attach(feedbackButton, 0, 0, 1, 1);

            Button backToWorkButton = new Button("Back to work");
            backToWorkButton.Clicked += delegate { BackToWorkButtonClicked(); };
            _grid.Attach(backToWorkButton, 0, 1, 1, 1);

        }

        private static void FeedbackButtonClicked()
        {
            // FIXME Open Browser...
            Console.WriteLine("Open Browser for Feedback.");
        }

        private void BackToWorkButtonClicked()
        {
            _app.State = AppState.Working;
            Close();
        }


    }

}