using System;
using System.Collections.Generic;
using Gtk;
using InteractiveOfficeClient.Models;

namespace InteractiveOfficeClient.Windows
{
    public class ActivitySelectionWindow : Gtk.Window
    {
        private InteractiveOfficeClient _app;
        private readonly Grid _grid = new Grid();
        private readonly Activity[] _activities;

        private readonly HashSet<Activity> _selectedActivites = new HashSet<Activity>();
        private readonly Button _continueButton = new Button("OK");
        private readonly Label _continueLabel = new Label("Select one or more activities.");

        public ActivitySelectionWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Break Time")
        {
            this._app = interactiveOfficeClient;
            Add(_grid);
            ShowLoading(true);
            _activities = Activity.DefaultActivities;

            int activityRowOffset;
            AddLabel("What do you feel like?", 0, 0);
            activityRowOffset = 1;


            for (int i = 0; i < _activities.Length; i++)
            {
                var activity = _activities[i];

                CheckButton b = new ActivityButton(activity);
                b.Clicked += delegate { SelectedActivity(activity, b.Active); };

                _grid.Attach(b, 0, activityRowOffset + i, 1, 1);
            }

            _continueButton.Clicked += delegate { ContinueButtonClicked(); };
            _grid.Attach(_continueButton, 1, activityRowOffset + _activities.Length, 1, 1);
            _grid.Attach(_continueLabel, 0, activityRowOffset + _activities.Length, 1, 1);



            UpdateContinueWidgets();

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

            UpdateContinueWidgets();
        }

        private void UpdateContinueWidgets()
        {
            var hasSelectedActivities = _selectedActivites.Count > 0;
            _continueButton.Sensitive = hasSelectedActivities;
            _continueLabel.Visible = !hasSelectedActivities;
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

            if (FeatureToggles.ShowFakePeopleSelection)
            {
                new PeopleSelectionWindow(_app).ShowAll();
            }
            else
            {
                _app.State = AppState.Break;
            }
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