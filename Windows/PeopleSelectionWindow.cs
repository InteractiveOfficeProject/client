using System;
using System.Net;
using System.Threading.Tasks;
using Gtk;
using InteractiveOfficeClient.Models;

namespace InteractiveOfficeClient.Windows
{
    public class PeopleSelectionWindow : Gtk.Window
    {
        private InteractiveOfficeClient _app;
        private readonly Grid _grid = new Grid();
        private readonly Widget _progressBar = new Label("Loading…");

        public PeopleSelectionWindow(InteractiveOfficeClient interactiveOfficeClient) : base("Break Time")
        {
            this._app = interactiveOfficeClient;
            Add(_grid);
            StartLoadingPeople();
        }

        private async void StartLoadingPeople()
        {
            Gtk.Application.Invoke(delegate
            {
                foreach (var c in _grid.Children)
                {
                    _grid.Remove(c);
                    Console.Write("Removed a child...");
                }
                _grid.Attach(_progressBar, 0, 0, 1, 1);
                ShowAll();
            });

            await Task.Run(() =>
            {
                // FIXME Add actual loading
                System.Threading.Thread.Sleep(1500);
                OnLoadComplete(User.DefaultUsers);
            });
        }

        private void OnLoadComplete(User[] users)
        {
            Gtk.Application.Invoke(delegate { _grid.Remove(_progressBar); });
            Gtk.Application.Invoke(delegate
            {
                _grid.Attach(new Label("Who do you want to take a break with?"), 0, 0, users.Length + 2, 1);
            });

            for (int i = 0; i < users.Length; i++)
            {
                var user = users[i];
                UserButton b = new UserButton(user);

                b.Clicked += delegate { SelectedUser(user); };
                Gtk.Application.Invoke(delegate { _grid.Attach(b, 0, i + 1, 1, 1); });
            }
            _grid.Attach(new Button("ok"), 0, users.Length + 2, 1, 1);

            Gtk.Application.Invoke(delegate { ShowAll(); });
        }

        private void SelectedUser(User user)
        {
            // TODO show "go to this place"
            _app.State = AppState.Break;
            Close();
        }
    }

    class UserButton : Gtk.ToggleButton
    {
        public UserButton(User user)
        {
            if (FeatureToggles.LoadUserIcons)
            {
                LoadImageWithFallBackLabel(user);
            }
            else
            {
                Label = $"{user.FirstName} {user.LastName}";
            }
        }

        private void LoadImageWithFallBackLabel(User user)
        {
            if (user.ProfilePictureUrlIsValid)
            {
                try
                {
                    Image = new Gtk.Image(HttpWebRequest.Create(user.ProfilePictureURL)
                        .GetResponse()
                        .GetResponseStream());
                }
                catch (System.Net.WebException e)
                {
                    /* Could not load image. Use label instead */
                    Label = $"{user.FirstName} {user.LastName}";
                }
            }
            else
            {
                Label = $"{user.FirstName} {user.LastName}";
            }
        }
    }
}
