using FinalProject_Samolevich.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window {
        ShopViewModel viewModel;
        public ShopWindow() {
            InitializeComponent();
            viewModel = new ShopViewModel(new PageShowService(), new JsonFileService(), new DialogService());
            DataContext = viewModel;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) => Close();

        private void btnSaleAll_Click(object sender, RoutedEventArgs e) {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @"../../Sounds/money.wav";
            sp.Load();
            sp.Play();
        }
    }
}
