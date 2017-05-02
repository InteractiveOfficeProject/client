using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Gtk;
using InteractiveOfficeClient.Models;

namespace InteractiveOfficeClient
{
    public class FeedbackWindow : Gtk.Window
    {
        private readonly InteractiveOfficeClient _app;
        private readonly Grid _grid = new Grid();
        private readonly Button _feedbackButton;

        public FeedbackWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Work Time")
        {
            this._app = interactiveOfficeClient;
            Add(_grid);


            _feedbackButton = new Button("Give Feedback");
            _feedbackButton.Clicked += delegate { FeedbackButtonClicked(); };
            _grid.Attach(_feedbackButton, 0, 0, 1, 1);

            Button backToWorkButton = new Button("Back to work");
            backToWorkButton.Clicked += delegate { BackToWorkButtonClicked(); };
            _grid.Attach(backToWorkButton, 0, 1, 1, 1);

        }

        private void FeedbackButtonClicked()
        {
            Gtk.Application.Invoke(delegate
            {
                Process.Start("https://goo.gl/forms/Ogz69BPZ9N7HJsBj2");
                _feedbackButton.Label = "Starting Browser…";
                _feedbackButton.Sensitive = false;
            });
        }

        private void BackToWorkButtonClicked()
        {
            _app.State = AppState.Working;
            Close();
        }


    }

}
