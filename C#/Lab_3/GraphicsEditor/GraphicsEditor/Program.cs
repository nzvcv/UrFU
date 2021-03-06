﻿using System;
using ConsoleUI;
using DrawablesUI;

namespace GraphicsEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var picture = new Picture();
            var ui = new DrawableGUI(picture);
            var app = new Application();

            app.AddCommand(new ExitCommand(app));
            app.AddCommand(new ExplainCommand(app));
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new PointCommand(picture));
            app.AddCommand(new LineCommand(picture));
            app.AddCommand(new CircleCommand(picture));
            app.AddCommand(new EllipseCommand(picture));
            app.AddCommand(new ListCommand(picture));
            app.AddCommand(new RemoveCommand(app, picture));

            picture.Changed += ui.Refresh;
            ui.Start();
            app.Run(Console.In);
            ui.Stop();
        }
    }
}
