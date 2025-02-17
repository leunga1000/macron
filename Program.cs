using System;
using Gtk;

namespace macron
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.macron.macron", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            win.Title = "Macron";
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }

}
