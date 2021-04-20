using System.Windows;
using System.Windows.Controls;

namespace FinalProject_Samolevich.PageShopSections {
    /// <summary>
    /// Логика взаимодействия для PageSalesSection.xaml
    /// </summary>
    public partial class PageSalesSection : Page {
        public PageSalesSection() {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        } // PageSalesSection

    } // PageSalesSection
} // FinalProject_Samolevich.PageShopSections
