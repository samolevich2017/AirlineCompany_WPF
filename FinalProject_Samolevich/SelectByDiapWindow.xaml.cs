using FinalProject_Samolevich.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для SelectByDiapWindow.xaml
    /// </summary>
    public partial class SelectByDiapWindow : Window {

        ApplicationViewModel vm;
        public SelectByDiapWindow() {
            InitializeComponent();
            vm = Application.Current.MainWindow.DataContext as ApplicationViewModel;
            DataContext = vm;
        } // method SelectByDiapWindow
    } // class SelectByDiapWindow
} // namespace FinalProject_Samolevich
