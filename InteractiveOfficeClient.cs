﻿using System;
using System.Dynamic;
using System.IO;
using System.Reflection;
using Gdk;
using GLib;

namespace InteractiveOfficeClient
{
    using Gtk;

    public class InteractiveOfficeClient
    {
        private static InteractiveOfficeClient Instance = new InteractiveOfficeClient();
        private ApplicationTimer _applicationTimer;
        private MainWindow mainWindow;


        private int _timeLeft;

        public int TimeLeft
        {
            get { return _timeLeft; }
            set
            {
                _timeLeft = value;
                mainWindow.UpdateUi();
            }
        }


        private AppState _appState = AppState.Paused;
        public bool IsPaused => State == AppState.Paused;
        public bool IsWorking => State == AppState.Working;
        public bool IsNotifying => State == AppState.NotifyingBreak || State == AppState.NotifyingWork;

        public AppState State
        {
            get { return _appState; }
            set
            {
                Gtk.Application.Invoke(delegate {
                    Console.WriteLine($"new state: {value}");
                    _appState = value;
                    _applicationTimer.ChangeState(value);
                    mainWindow.UpdateUi();
                });

            }
        }
        private InteractiveOfficeClient()
        {
        }

        static void Main()
        {
            Instance.Run();
        }

        public void Run()
        {
            Application.Init();

            mainWindow = new MainWindow(this);
            _applicationTimer = new ApplicationTimer(this);
            new IopTrayIcon(this);


            Application.Run();
        }

        public void ToggleAppVisibility()
        {
            mainWindow.Visible = !mainWindow.Visible;
        }

        public void Show()
        {
            mainWindow.Deiconify();
            mainWindow.Visible = true;
        }

        public void TriggerNotification()
        {
                if (IsWorking)
                {
                    TriggerNotification(AppState.NotifyingBreak);
                }
                else
                {
                    TriggerNotification(AppState.NotifyingWork);
                }
        }

        private void TriggerNotification(AppState newState)
        {
            Gtk.Application.Invoke(delegate
            {
                if (IsWorking)
                {
                    new ActivitySelectionWindow(this).ShowAll();
                }
                else
                {
                    new FeedbackWindow(this).ShowAll();
                }
            });
            State = newState;
        }
    }
}