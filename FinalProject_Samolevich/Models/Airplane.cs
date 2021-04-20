using FinalProject_Samolevich.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject_Samolevich.Models {

    // Модель данных Самолета
    public class Airplane:INotifyPropertyChanged {

        IWindowShow windowShow; // реализация операций для работы с новыми окнами (нужно для команды открытия подробной информации)

        private string _airplaneName;           // название самолета
        private int _numberOfSeats;             // количество мест
        private double _cruisingSpeed;          // крейсерская скорость
        private double _rangeOfFlight;          // дальность полета
        private double _maximumTakeOffWeight;   // максимальная взлетная масса
        private double _maximumFlightAltitude;  // максимальная высота полета
        private string _registerNumber;         // регистрационный номер
        private string _pathToImage;            // фото самолета
        private double _priceOfAirplane;        // цена самолета
        private double _fuelConsumption;        // часовой расход топлива

        // название самолета
        public string AirplaneName {
            get => _airplaneName;
            set {
                _airplaneName = value;
                OnPropertyChanged("AirplaneName");
            } // set
        } // AirplaneName

        // количество мест
        public int NumberOfSeats {
            get => _numberOfSeats;
            set {
                _numberOfSeats = value;
                OnPropertyChanged("NumberOfSeats");
            } // set
        } // NumberOfSeats

        // крейсерская скорость
        public double CruisingSpeed {
            get => _cruisingSpeed;
            set {
                _cruisingSpeed = value;
                OnPropertyChanged("CruisingSpeed");
            } // set
        } // CruisingSpeed

        // дальность полета
        public double RangeOfFlight {
            get => _rangeOfFlight;
            set {
                _rangeOfFlight = value;
                OnPropertyChanged("RangeOfFlight");
            } // set
        } // RangeOfFlight

        // максимальная взлетная масса
        public double MaximumTakeOffWeight {
            get => _maximumTakeOffWeight;
            set {
                _maximumTakeOffWeight = value;
                OnPropertyChanged("MaximumTakeOffWeight");
            } // set
        } // MaximumTakeOffWeight 

        // максимальная высота полета
        public double MaximumFlightAltitude {
            get => _maximumFlightAltitude;
            set {
                _maximumFlightAltitude = value;
                OnPropertyChanged("MaximumFlightAltitude");
            } // set
        } // MaximumFlightAltitude

        // регистрационный номер
        public string RegisterNumber {
            get => _registerNumber;
            set {
                _registerNumber = value;
                OnPropertyChanged("RegisterNumber");
            } // set
        } // RegisterNumber

        // фото самолета
        public string PathToImage {
            get => _pathToImage;
            set {
                _pathToImage = value;
                OnPropertyChanged("PathToImage");
            } // set
        } // PathToImage

        // цена самолета
        public double PriceOfAirplane {
            get => _priceOfAirplane;
            set {
                _priceOfAirplane = value;
                OnPropertyChanged("PriceOfAirplane");
            } // set
        } // PriceOfAirplane

        // часовой расход топлива
        public double FuelConsumption {
            get => _fuelConsumption;
            set {
                _fuelConsumption = value;
                OnPropertyChanged("FuelConsumption");
            } // set
        } // FuelConsumption

        // конструктор по умолчанию
        public Airplane(){}

        // конструктор с параметрами
        public Airplane(string name, int number, double speed, double range, double max_weight, double max_altitude, string regNum, string path, double price, double fuelCons) {
            AirplaneName = name;
            NumberOfSeats = number;
            CruisingSpeed = speed;
            RangeOfFlight = range;
            MaximumTakeOffWeight = max_weight;
            MaximumFlightAltitude = max_altitude;
            RegisterNumber = regNum;
            PathToImage = path;
            PriceOfAirplane = price;
            FuelConsumption = fuelCons;
        } // Airplane

        public static ObservableCollection<Airplane> GetAirplanes() {
            ObservableCollection<Airplane> airplanes = new ObservableCollection<Airplane>() {
                new Airplane{AirplaneName="A319-Neo", NumberOfSeats= 68, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-NUa", NumberOfSeats= 68, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-Neo", NumberOfSeats= 87, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-IO", NumberOfSeats= 68, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-Neo", NumberOfSeats= 68, CruisingSpeed=3905d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-JAK", NumberOfSeats= 90, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-Neo", NumberOfSeats= 68, CruisingSpeed=3423d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-Neo", NumberOfSeats= 68, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }, 
                new Airplane{AirplaneName="A319-Neo", NumberOfSeats= 68, CruisingSpeed=345d, RangeOfFlight=10000d, MaximumTakeOffWeight=1000, MaximumFlightAltitude=17000, RegisterNumber="AK-39129PV2", PathToImage=@"../AirplanesImages/A319-neo.jpg", PriceOfAirplane=50000d }
            };
            return airplanes;
        } // GetAirplanes

        // ----------------------------------- Команды ----------------------------------------

        // Команда для открытия окна просмотра подробной информации
        private RelayCommand _openDetailsWindowCommand;
        public RelayCommand OpenDetailsWindowCommand {
            get {
                return _openDetailsWindowCommand ??
                    (_openDetailsWindowCommand = new RelayCommand(obj => { 
                        windowShow = new WindowShowService(); 
                        windowShow.OpenWindowDetails(); 
                    }));
            } // get
        } // OpenDetailsWindowCommand 

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error in Airplane", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged

    } // Airplane
} // FinalProject_Samolevich.Models 
