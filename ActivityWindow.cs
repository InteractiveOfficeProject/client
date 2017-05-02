using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gtk;
using InteractiveOfficeClient.Models;

namespace InteractiveOfficeClient
{
    public class ActivityWindow : Gtk.Window
    {
        private InteractiveOfficeClient _app;
        private readonly Grid _grid = new Grid();
        private readonly Activity[] _activities;

        private readonly HashSet<Activity> _selectedActivites = new HashSet<Activity>();

        public ActivityWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Break Time")
        {
            this._app = interactiveOfficeClient;
            Add(_grid);
            ShowLoading(true);
            _activities = Activity.DefaultActivities;

            int activityRowOffset;
            if (FeatureToggles.FakeTakeBreakNotification)
            {
                AddLabel("It is time for you to take a break.", 0, 0);
                AddLabel("What do you feel like?", 1, 0);
                activityRowOffset = 2;
            }
            else
            {
                AddLabel("What do you feel like?", 0, 0);
                activityRowOffset = 1;
            }


            for (int i = 0; i < _activities.Length; i++)
            {
                var activity = _activities[i];

                CheckButton b = new ActivityButton(activity);
                b.Clicked += delegate { SelectedActivity(activity, b.Active); };

                _grid.Attach(b, 0, activityRowOffset + i, 1, 1);
            }

            Button continueButton = new Button("OK");
            continueButton.Clicked += delegate { ContinueButtonClicked(); };
            _grid.Attach(continueButton, 1, activityRowOffset + _activities.Length, 1, 1);

            ShowLoading(false);
        }

        private void SelectedActivity(Activity activity, bool isSelected)
        {
            if (isSelected)
            {
                Console.WriteLine($"Selected {activity}");
                _selectedActivites.Add(activity);
            }
            else
            {
                Console.WriteLine($"De-Selected {activity}");
                _selectedActivites.Remove(activity);
            }
        }

        private void AddLabel(string text, int row, int col)
        {
            _grid.Attach(new Label(text), row, col, 1, 1);
        }

        private void ContinueButtonClicked()
        {
            Console.WriteLine($"Selected activities:");
            foreach (var activity in _selectedActivites)
            {
                Console.WriteLine($"  {activity}");
            }
            _app.State = AppState.Break;
            Close();
        }


        private void ShowLoading(bool isLoading)
        {
            Console.WriteLine($"IsLoading: {isLoading}");
        }
    }

    class ActivityButton : Gtk.CheckButton
    {
        public ActivityButton(Activity a)
        {
            if (FeatureToggles.ShowMissingActivityIcons) Image = new Gtk.Image(Gtk.Stock.MissingImage);

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