using System;
using System.Threading.Tasks;
using Gtk;
using InteractiveOfficeClient.Models;

namespace InteractiveOfficeClient
{
    public class ActivityWindow : Gtk.Window
    {
        private InteractiveOfficeClient _app;
        private readonly Grid _grid = new Grid();

        public ActivityWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Break Time")
        {
            this._app = interactiveOfficeClient;
            Add(_grid);
            ShowLoading(true);
            var activities = Activity.DefaultActivities;

            for (int i = 0; i < activities.Length; i++)
            {
                var activity = activities[i];

                Button b = new ActivityButton(activity);
                b.Clicked += delegate { ActivitySelected(activity); };

                _grid.Attach(b, 0, i, 1, 1);
            }
            ShowLoading(false);
        }

        private void ActivitySelected(Activity activity)
        {
            Console.WriteLine($"Selected {activity}");
            _app.State = AppState.Break;
            Close();
        }

        private void ShowLoading(bool isLoading)
        {
            Console.WriteLine($"IsLoading: {isLoading}");
        }

    }

    class ActivityButton: Gtk.Button
    {
        public ActivityButton(Activity a)
        {
            if (a.MaximumUsers > 0)
            {
                Label = $"{a.Name} ({a.MaximumUsers})";
            }
            else
            {
                Label = $"{a.Name}";
            }
        }
    }
}