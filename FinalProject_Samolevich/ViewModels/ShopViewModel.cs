using FinalProject_Samolevich.Models;
using FinalProject_Samolevich.PageShopSections;
using FinalProject_Samolevich.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject_Samolevich {
    public class ShopViewModel : INotifyPropertyChanged {

        IPageShow ipage; // реализация методов для работы со страницами
        IFileService ifile; // реализация методов для работы с файлами
        IDialogService idialog; // реализация методов для работы с диалогами

        // Текущая страничка в окне магазина 
        // В зависимости от выбранного раздела, отображается нужная View
        private Page _currentPage;
        public Page CurrentPage {
            get => _currentPage;
            set {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            } // set
        } // CurrentPage

        // выбранная авиакомпания в коллекции
        private AirlineCompany _selectedCompany;
        public AirlineCompany SelectedCompany {
            get => _selectedCompany;
            set {
                _selectedCompany = value;
                OnPropertyChanged("SelectedCompany");
            } // set
        } // SelectedCompany

        // Коллекция товаров (самолетов) магазина для раздела покупок
        public ObservableCollection<Airplane> Goods { get; set; }

        // выбранный самолет в коллекции 
        private Airplane _selectedAirplane;
        public Airplane SelectedAirplane {
            get => _selectedAirplane;
            set {
                _selectedAirplane = value;
                OnPropertyChanged("SelectedAirplane");
            } // set
        } // SelectedAirplane

        ObservableCollection<Airplane> airplanes = new ObservableCollection<Airplane>() {
                new Airplane("A319neo", 124, 890d, 7750d, 75000d, 11900d, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2800d),
                new Airplane("A319", 160, 820d, 6800d, 75500d, 11900d, "AK-39549PV2", @"../AirplanesImages/Airbus-A319.jpg", 80000d, 2600d),
                new Airplane("A320neo", 320, 830d, 6850d, 78000d, 11500d, "AK-37529PV2", @"../AirplanesImages/Airbus-A320neo.jpg", 97500d, 3200d),
                new Airplane("Boeing 737 Max 7", 170, 840d, 7000d, 80290d, 12000d, "AK-3239PV2", @"../AirplanesImages/737max7.jpg", 126000d, 4100d),
                new Airplane("Boeing 777-9", 763, 900d, 14000d, 351500d, 13000d, "AK-3239PV2", @"../AirplanesImages/boeing777.jpg", 247000d, 4800d),
                new Airplane("Comac CR929", 678, 870d, 13000d, 178500d, 12500d, "AK-3239PV2", @"../AirplanesImages/Comac-CR929.jpg", 310000d, 3700d),
                new Airplane("Mitsubishi MRJ", 560, 840d, 11000d, 130500d, 10000d, "AK-3239PV2", @"../AirplanesImages/Mitsubishi-MRJ.jpg", 247000d, 4800d),
                new Airplane("A350-1000", 475, 905d, 14800d, 29500d, 13100d, "AK-23429PV2", @"../AirplanesImages/a350-1000-f.jpg", 113000d, 2800d),
                new Airplane("A380", 1225, 980d, 15000d, 560000d, 13100d, "AK-23429PV2", @"../AirplanesImages/Airbus-A380.jpg", 186000d, 3400d),
                new Airplane("Saab 340", 37, 460d, 1500d, 13150d, 7600d, "AK-23429PV2", @"../AirplanesImages/Saab-340-NextJet.jpg", 31000d, 400d),
                new Airplane("Bombardier CRJ-550", 50, 830d, 1850d, 29500d, 12500d, "AK-23429PV2", @"../AirplanesImages/Saab-340-NextJet.jpg", 52900d, 465d)
            };

        // конструкторы 
        public ShopViewModel() { }
        public ShopViewModel(IPageShow _ipage, IFileService _ifile, IDialogService _idialog) {
            ipage = _ipage;
            ifile = _ifile;
            idialog = _idialog;

            Goods = airplanes;

        } // ShopViewModel

        // ------------------------------- Команды ----------------------------------

        // Команда для открытия раздела покупок (он же отдельная страничка - View с ViewModel магазина)
        private RelayCommand _openPageBuy;
        public RelayCommand OpenPageBuy {
            get {
                return _openPageBuy ??
                    (_openPageBuy = new RelayCommand(obj => {
                        CurrentPage = ipage.ShowPagePurchases();
                    }));
            } // get
        } // OpenPageBuy 

        // Команда для открытия раздела продаж (он же отдельная страничка - View с главным ViewModel(ApplicationVM)) 
        private RelayCommand _openPageSale;
        public RelayCommand OpenPageSale {
            get {
                return _openPageSale ??
                    (_openPageSale = new RelayCommand(obj => CurrentPage = ipage.ShowPageSales()));
            } // get
        } // OpenPagesale 

        // Команда для покупки самолета
        private RelayCommand _buyAirplane;
        public RelayCommand BuyAirplane {
            get {
                return _buyAirplane ??
                    (_buyAirplane = new RelayCommand(obj => {
                        // добавление самолета с характеристиками выбранного для покупки
                        SelectedCompany.Airplanes.Add(new Airplane(SelectedAirplane.AirplaneName, SelectedAirplane.NumberOfSeats, SelectedAirplane.CruisingSpeed, SelectedAirplane.RangeOfFlight, SelectedAirplane.MaximumTakeOffWeight, SelectedAirplane.MaximumFlightAltitude, SelectedAirplane.RegisterNumber, SelectedAirplane.PathToImage, SelectedAirplane.PriceOfAirplane, SelectedAirplane.FuelConsumption));
                        // списывание средств со счета
                        SelectedCompany.AccountOfCompany -= SelectedAirplane.PriceOfAirplane;
                        // аудио списывания средств
                        SoundPlayer sp = new SoundPlayer();
                        sp.SoundLocation = @"../../Sounds/money.wav";
                        sp.Load();
                        sp.Play();
                    },
                    obj => SelectedCompany != null && SelectedAirplane != null && SelectedCompany.AccountOfCompany >= SelectedAirplane.PriceOfAirplane));
            } // get
        } // BuyAirplane

        // -----------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged

    } // ShopViewModel
} // FinalProject_Samolevich
