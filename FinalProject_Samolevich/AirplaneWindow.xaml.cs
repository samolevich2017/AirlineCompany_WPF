using System.Windows;

namespace FinalProject_Samolevich {
    /// <summary>
    /// Логика взаимодействия для AirplaneWindow.xaml
    /// </summary>
    public partial class AirplaneWindow : Window {
        public AirplaneWindow() {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        } // AirplaneWindow

        // Событие клика - закрывает это окно
        private void Button_Click(object sender, RoutedEventArgs e) => Close();

    } // class AirplaneWindow
} // namespace FinalProject_Samolevich
