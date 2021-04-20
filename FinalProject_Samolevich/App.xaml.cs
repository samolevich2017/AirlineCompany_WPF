using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject_Samolevich {
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application {

        public App() {
            // Формирование окна-заставки выполняется до инициализации компонентов
            SplashScreen splash = new SplashScreen(@"Images\splashscreen.jpg");

            splash.Show(false, true);

            splash.Close(new TimeSpan(0, 0, 5));

            InitializeComponent();
        } // App

    }
}
