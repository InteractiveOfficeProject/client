using System;
using System.Threading.Tasks;
using Gtk;

namespace InteractiveOfficeClient
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
                _grid.Attach(_progressBar, 0, 0, 1, 1 );
                ShowAll();
                Console.Write("Added \"_progressBar\"...");
            });

            await Task.Run(() =>
            {
                // FIXME Add actual loading
                System.Threading.Thread.Sleep(3000);
                OnLoadComplete();
            });
        }

        private void OnLoadComplete()
        {
            Gtk.Application.Invoke(delegate
            {
                _grid.Remove(_progressBar);
                // FIXME Show people
                _grid.Attach(new Button("ok"), 0, 0, 1, 1);

                ShowAll();
            });
        }
    }
}