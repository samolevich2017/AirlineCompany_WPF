using FinalProject_Samolevich.Services;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject_Samolevich.PageShopSections {
    /// <summary>
    /// Логика взаимодействия для PagePurchasesSection.xaml
    /// </summary>
    public partial class PagePurchasesSection : Page {

        ShopViewModel viewModel;
        public PagePurchasesSection() {
            InitializeComponent();
            viewModel = new ShopViewModel( new PageShowService(), new JsonFileService(), new DialogService());
            // Инициализируем поле "Выбранная компания", данной модели данных, значение выбранной компании в главном окне
            // для работы с Выбранной пользователем компании. Что при покупке самолета, была возможность добавить его в ангар
            // этой компании.
            viewModel.SelectedCompany = ((ApplicationViewModel)Application.Current.MainWindow.DataContext).SelectedCompany;
            DataContext = viewModel;
        } // PagePurchasesSection
    } // PagePurchasesSection
} // FinalProject_Samolevich.PageShopSections
