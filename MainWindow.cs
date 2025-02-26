using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace macron
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _buttonAirportOff = null;
        [UI] private Button _buttonAirportClear = null;
        [UI] private Button _buttonExit = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _buttonAirportOff.Clicked += ButtonAirportOff_Clicked;
            _buttonAirportClear.Clicked += ButtonAirportClear_Clicked;
            _buttonExit.Clicked += ButtonExit_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void ButtonAirportOff_Clicked(object sender, EventArgs a)
        {
            // _counter++;
            // _label1.Text = "Turning Airport Off" + _counter + " time(s).";
            ControlAirport.TurnAirportOff();
            _label1.Text = "Turned Airport Off";
        }

        private void ButtonAirportClear_Clicked(object sender, EventArgs a)
        {
            _label1.Text = "Clearing settings";
            ControlAirport.ResetSettings();
            _label1.Text = "Cleared Airport Settings";
        }

        private void ButtonExit_Clicked(object sender, EventArgs a)
        {
            // _label1.Text = "Exit";
            this.Destroy();  // flash red full screen
            Application.Quit();
        }
    }
}
