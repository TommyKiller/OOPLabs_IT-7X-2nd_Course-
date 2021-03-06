﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TransportLibrary;

namespace TransportLab
{
    static class CityTransport
    {
        public static ApplicationContext Context { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Transport.Cars = new Dictionary<CarID, Transport>();
            Route.Routes = new Dictionary<RouteID, Route>();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Context = new ApplicationContext(new MainMenu());
            Application.Run(Context);
        }
    }
}
