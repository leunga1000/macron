using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace macron
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _buttonAirportOff = null;
        [UI] private Button _buttonAirportOn = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _buttonAirportOff.Clicked += ButtonAirportOff_Clicked;
            _buttonAirportOn.Clicked += ButtonAirportOn_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void ButtonAirportOff_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text = "Turning Airport Off" + _counter + " time(s).";
            ControlAirport.TurnAirportOff();
        }

        private void ButtonAirportOn_Clicked(object sender, EventArgs a)
        {
            _label1.Text = "Turning Airport On";
            ControlAirport.TurnAirportOn();
        }
    }
}
