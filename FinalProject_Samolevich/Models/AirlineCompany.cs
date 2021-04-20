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

    // Модель данных Авиакомпании
    public class AirlineCompany:INotifyPropertyChanged {

        // название компании 
        private string _nameOfCompany;
        public string NameOfCompany {
            get => _nameOfCompany;
            set {
                _nameOfCompany = value;
                OnPropertyChanged("NameOfCompany");
            } // set
        } // NameOfCompany

        // адрес компании
        private string _adressOfCompany;
        public string AdressOfCompany {
            get => _adressOfCompany;
            set {
                _adressOfCompany = value;
                OnPropertyChanged("AdressOfCompany");
            } // set
        } // AdressOfCompany 

        // генеральный директор
        private CEO _ceo;
        public CEO Ceo {
            get => _ceo;
            set {
                _ceo = value;
                OnPropertyChanged("Ceo");
            } // set
        } // Ceo

        // список самолетов
        private ObservableCollection<Airplane> _airplanes;
        public ObservableCollection<Airplane> Airplanes {
            get => _airplanes;
            set {
                _airplanes = value;
                OnPropertyChanged("Airplanes");
            } // set
        } // Airplanes

        // счет компании
        private double _accountOfCompany;
        public double AccountOfCompany {
            get => _accountOfCompany;
            set {
                _accountOfCompany = value;
                OnPropertyChanged("AccountOfCompany");
            } // set
        } // AccountOfCompany

        // конструктор по умолчанию
        public AirlineCompany() {}

        // конструктор с параметрами
        // !!! Параметр коллекции самолетов ObservableCollection<Airplane> newAirplanes - необязательный !!!
        // Так как при создании новой авиакомпании, у нее не имеется ни одного самолета. 
        // Для этого, нужно приобрести его в магазине.
        public AirlineCompany(string name, string adress, CEO newCeo, double account, ObservableCollection<Airplane> newAirplanes=null) {
            NameOfCompany = name;
            AdressOfCompany = adress;
            Ceo = newCeo;
            Airplanes = newAirplanes;
            AccountOfCompany = account;
        } // AirlineCompany


        // ---------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged

    } // AirlineCompany 
} // FinalProject_Samolevich.Models
