using FinalProject_Samolevich.Models;
using FinalProject_Samolevich.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FinalProject_Samolevich {

    // Модель представления
    public class ApplicationViewModel : DependencyObject, INotifyPropertyChanged {

        IWindowShow windShow; // реализация операций для работы с новыми окнами
        IDialogService dialogService; // реализация операций для работы с диалогами
        IFileService fileService; // реализация операций для работы с файлами

        // коллекция обьектов - Авиакомпании
        public ObservableCollection<AirlineCompany> CollectionCompany { get; set; }

        ObservableCollection<Airplane> airplanes1 = new ObservableCollection<Airplane>() {
                new Airplane("A319-Neo", 68, 345d, 10000d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2600d),
                new Airplane("A319-Neo", 68, 345d, 10000d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2500d),
                new Airplane("A319-Neo", 68, 345d, 10000d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2550d),
                new Airplane("A319-Neo", 68, 345d, 10000d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2100d),
                new Airplane("A319-Neo", 68, 345d, 10000d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2000d)
            };

        ObservableCollection<Airplane> airplanes2 = new ObservableCollection<Airplane>() {
                new Airplane("A319", 89, 345d, 7281d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2800d),
                new Airplane("A319", 89, 345d, 7281d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2800d),
                new Airplane("A319", 89, 345d, 7281d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2800d),
                new Airplane("A319", 89, 345d, 7281d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2800d),
                new Airplane("A319", 89, 345d, 7281d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 2800d)
            };

        ObservableCollection<Airplane> airplanes3 = new ObservableCollection<Airplane>() {
                new Airplane("A319-Neo", 68, 345d, 8900d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 1800d),
                new Airplane("A319-Neo", 68, 345d, 1200d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 1800d),
                new Airplane("A319-Neo", 68, 345d, 12000d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 1800d),
                new Airplane("A319-Neo", 68, 345d, 3400d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 1800d),
                new Airplane("A319-Neo", 68, 345d, 6789d, 1000, 17000, "AK-39129PV2", @"../AirplanesImages/A319-neo.jpg", 50000d, 1800d)
            };

        // выбранная авиакомпания в коллекции
        private AirlineCompany _selectedCompany;
        public AirlineCompany SelectedCompany {
            get => _selectedCompany;
            set {
                _selectedCompany = value;
                // передаем фильтру коллекцию самолетов выбранной компании
                Items = CollectionViewSource.GetDefaultView(SelectedCompany.Airplanes);
                Items.Filter = FilterAirplane;
                OnPropertyChanged("SelectedCompany");
            } // set
        } // SelectedCompany

        // выбранный самолет в коллекции 
        private Airplane _selectedAirplane;
        public Airplane SelectedAirplane {
            get => _selectedAirplane;
            set {
                _selectedAirplane = value;
                OnPropertyChanged("SelectedAirplane");
            } // set
        } // SelectedAirplane 

        #region Фильтр для поиска
        public string FilterText {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        } // FilterText

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(ApplicationViewModel), new PropertyMetadata("", FilterText_Changed));

        // Событие изменения текста в поиске
        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var current = d as ApplicationViewModel;
            if (current != null) {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterAirplane;
            } // if
        } // FilterText_Changed

        // Коллекция в которой происходит поиск\фильтрация
        public ICollectionView Items {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        } // Items

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("ItemsProperty", typeof(ICollectionView), typeof(ApplicationViewModel), new PropertyMetadata(null));

        // Проверка - если в блоке с информацией о самолете, содержится введенный текст
        // то возвращается true, иначе false.
        private bool FilterAirplane(object obj) {
            bool result = true;
            Airplane current = obj as Airplane;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null &&
                !current.AirplaneName.Contains(FilterText) && !current.NumberOfSeats.ToString().Contains(FilterText) &&
                !current.MaximumTakeOffWeight.ToString().Contains(FilterText) && !current.FuelConsumption.ToString().Contains(FilterText))
                result = false;
            return result;
        } // FilterAirplane

        #endregion

        // конструктор
        public ApplicationViewModel() { }
        public ApplicationViewModel(IWindowShow windShow, IDialogService dialogService, IFileService fileService) {

            this.windShow = windShow;
            this.dialogService = dialogService;
            this.fileService = fileService;

            // коллекция компаний
            CollectionCompany = new ObservableCollection<AirlineCompany>();
            CollectionCompany = fileService.Load(@"../../SavedDataFiles/Data.json");

        } // ApplicationViewModel


        // Команды
        // ------------------------------------------------------------------------

        // Команда выхода из приложения
        private RelayCommand _quitCommand;
        public RelayCommand QuitCommand {
            get {
                return _quitCommand ??
                    (_quitCommand = new RelayCommand(obj => Application.Current.Shutdown()));
            } // get
        } // QuitCommand

        // Команда для открытия окна с информацией о программе
        private RelayCommand _openAboutProgramWindow;
        public RelayCommand OpenAboutProgramWindow {
            get {
                return _openAboutProgramWindow ??
                    (_openAboutProgramWindow = new RelayCommand(obj => windShow.OpenAboutProgramWindow()));
            } // get
        } // OpenAboutProgramWindow 

        // Команда для открытия окна управления авиакомпаниями
        private RelayCommand _openAMWindowCommand;
        public RelayCommand OpenAMWindowCommand {
            get {
                return _openAMWindowCommand ??
                    (_openAMWindowCommand = new RelayCommand(obj => windShow.OpenWindowManagement()));
            } // get
        } // OpenAirlineManagementWindow

        // Команда для открытия окна отбора по диапазону горючего
        private RelayCommand _openSelectWindow;
        public RelayCommand OpenSelectWindow {
            get {
                return _openSelectWindow ??
                    (_openSelectWindow = new RelayCommand(obj => {
                        windShow.OpenWindowSelect();
                    },
                    obj => SelectedCompany != null && SelectedCompany.Airplanes.Count > 1));
            } // get
        } // OpenSelectWindow

        // Команда для открытия окна магазина самолетов
        private RelayCommand _openShopWindowCommand;
        public RelayCommand OpenShopWindowCommand {
            get {
                return _openShopWindowCommand ??
                    (_openShopWindowCommand = new RelayCommand(obj => windShow.OpenWindowShop()));
            } // get
        } // OpenShopWindowCommand

        public bool OpenShopEnabled => OpenShopWindowCommand.CanExecute(SelectedCompany);

        // Команда для сортировки самолетов по дальности полета
        private RelayCommand _sortingByRangeOfFlight;
        public RelayCommand SortingByRangeOfFlight {
            get {
                return _sortingByRangeOfFlight ??
                    (_sortingByRangeOfFlight = new RelayCommand(obj => {
                        SelectedCompany.Airplanes = new ObservableCollection<Airplane>(SelectedCompany.Airplanes.OrderBy(o => o.RangeOfFlight));
                    },
                    obj => _selectedCompany != null));
            } // get
        } // SortingByRangeOfFlight 

        // Команда для удаления авиакомпании
        private RelayCommand _removeAirlineCommand;
        public RelayCommand RemoveAirlineCommand {
            get {
                return _removeAirlineCommand ??
                    (_removeAirlineCommand = new RelayCommand(obj => {
                        SelectedCompany.Airplanes.Clear();
                        CollectionCompany.Remove(SelectedCompany);
                    },
                    obj => _selectedCompany != null));
            } // get
        } // RemoveAirlineCommand 

        // Команда для добавления авиакомпании
        private RelayCommand _addAirlineCommand;
        public RelayCommand AddAirlineCommand {
            get {
                return _addAirlineCommand ??
                    (_addAirlineCommand = new RelayCommand(obj => {
                        AirlineCompany airline = new AirlineCompany("Измените это поле", "Измените это поле", new CEO("Измените это поле", "Измените это поле", "Измените это поле"), 200000d, new ObservableCollection<Airplane>());
                        CollectionCompany.Add(airline);
                    }));
            } // get
        } // AddAirlineCommand 

        // Команда для сохранения данных в файл
        private RelayCommand _saveToFile;
        public RelayCommand SaveToFile {
            get {
                return _saveToFile ??
                    (_saveToFile = new RelayCommand(obj => {
                        string filePath = "../../SavedDataFiles/Data.json";
                        if (dialogService.FilePath != null) {
                            fileService.Save(dialogService.FilePath, CollectionCompany);
                            dialogService.ShowMessage($"Данные сохранены в {dialogService.FilePath}!");
                        }
                        else {
                            fileService.Save(filePath, CollectionCompany);
                            dialogService.ShowMessage($"Данные сохранены в {filePath}!");
                        } // if/else
                    }));
            } // get
        } // SaveToFile

        // Команда для открытия диалога сохранения файла
        private RelayCommand _openSaveFileDialog;
        public RelayCommand OpenSaveFileDialog {
            get {
                return _openSaveFileDialog ??
                    (_openSaveFileDialog = new RelayCommand(obj => {
                        try {
                            if (dialogService.SaveFileDialog()) {
                                fileService.Save(dialogService.FilePath, CollectionCompany);
                                dialogService.ShowMessage("Файл успешно сохранен!");
                            } // if
                        }
                        catch (Exception ex) {
                            dialogService.ShowMessage(ex.Message);
                        } // try/catch
                    }));
            } // get
        } // OpenSaveFileDialog 

        // Команда для открытия диалога загрузки файла
        private RelayCommand _openLoadFileDialog;
        public RelayCommand OpenLoadFileDialog {
            get {
                return _openLoadFileDialog ??
                    (_openLoadFileDialog = new RelayCommand(obj => {

                        try {
                            if (dialogService.OpenFileDialog()) {
                                var companies = fileService.Load(dialogService.FilePath);

                                if(CollectionCompany.Count > 0)
                                    CollectionCompany.Clear();

                                foreach (var comp in companies)
                                    CollectionCompany.Add(comp);

                                dialogService.ShowMessage("Данные успешно загружены!");

                            } // if
                        }
                        catch (Exception ex) {
                            dialogService.ShowMessage(ex.Message);
                        } // try/catch

                    }));
            } // get
        } // OpenLoadFileDialog 

        // Команда для продажи самолета
        private RelayCommand _saleAirplaneCommand;
        public RelayCommand SaleAirplaneCommand {
            get {
                return _saleAirplaneCommand ??
                    (_saleAirplaneCommand = new RelayCommand(obj => {
                        double sum = SelectedAirplane.PriceOfAirplane;
                        // удаление выбранного самолета из коллекции
                        SelectedCompany.Airplanes.Remove(SelectedAirplane);
                        // перезапись файла 
                        string filePath = "../../SavedDataFiles/Data.json";
                        if (dialogService.FilePath != null)
                            fileService.Save(dialogService.FilePath, CollectionCompany);
                        else
                            fileService.Save(filePath, CollectionCompany);
                        // аудио списывания средств
                        SoundPlayer sp = new SoundPlayer();
                        sp.SoundLocation = @"../../Sounds/money.wav";
                        sp.Load();
                        sp.Play();
                        SelectedCompany.AccountOfCompany += sum;
                    },
                    obj => SelectedAirplane != null && SelectedCompany != null));

            } // get
        } // SaleAirplaneCommand 


        // ------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged

    } // ApplicationViewModel 
} // FinalProject_Samolevich 
