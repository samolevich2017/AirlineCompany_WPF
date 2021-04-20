using FinalProject_Samolevich.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject_Samolevich {
    /// <summary>
    /// Логика взаимодействия для AirlineManagementWindow.xaml
    /// </summary>
    public partial class AirlineManagementWindow : Window {

        public AirlineManagementWindow() {
            InitializeComponent();
            
            DataContext = Application.Current.MainWindow.DataContext;

        } // AirlineManagementWindow

        // Событие клика по кнопке Закрыть
        private void btnComebackToMain_Click(object sender, RoutedEventArgs e) => Close();

    } // AirlineManagementWindow
} // namespace FinalProject_Samolevich
