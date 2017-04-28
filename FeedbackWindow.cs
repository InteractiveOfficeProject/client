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
            feedbackButton.Clicked += delegate { FeedbackButtonClicked(); };
            _grid.Attach(feedbackButton, 0, 0, 1, 1);

            Button backToWorkButton = new Button("Back to work");
            backToWorkButton.Clicked += delegate { BackToWorkButtonClicked(); };
            _grid.Attach(backToWorkButton, 0, 1, 1, 1);

        }

        private static void FeedbackButtonClicked()
        { 
            System.Diagnostics.Process.Start ("xdg-open https://l.facebook.com/l.php?u=https%3A%2F%2Fdocs.google.com%2Fforms%2Fd%2F16LmorfEAbZp0Ugxh3tGwoobcUsxFAfOFgiezMD4K9wE%2F&h=ATPvUTvsJcpaXE0dmgeeLc21RZz0sdqxZYs9Tqc49tgQnA-Fw0rvfOZAYEs97-joPsHGCgj7u_iYpe53-1EORnlj7tAQDq6sFScaDyR9yVAsAG30RsZ2DBmG2AdsqBKm");
        }

        private void BackToWorkButtonClicked()
        {
            _app.State = AppState.Working;
            Close();
        }


    }

}