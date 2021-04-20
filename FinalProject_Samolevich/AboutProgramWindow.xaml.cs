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
    /// Логика взаимодействия для AboutProgramWindow.xaml
    /// </summary>
    public partial class AboutProgramWindow : Window {
        public AboutProgramWindow() {
            InitializeComponent();
        } // AboutProgramWindow

        // Событие клика по кнопке Закрыть
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

    } // class AboutProgramWindow
} // namespace FinalProject_Samolevich
