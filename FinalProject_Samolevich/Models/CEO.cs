using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinalProject_Samolevich.Models {

    // Модель данных о ген.директоре
    public class CEO :INotifyPropertyChanged {

        // фамилия 
        private string _surname;
        public string Surname {
            get => _surname;
            set {
                _surname = value;
                OnPropertyChanged("Surname");
            } // set
        } // SurnameAndName

        // имя
        private string _name;
        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged("Name");
            } // set
        } // Name

        // отчество
        private string _patronymic;
        public string Patronymic {
            get => _patronymic;
            set {
                _patronymic = value;
                OnPropertyChanged("Patronymic");
            } // set
        } // Patronymic

        // фото
        private string _pathToImage;
        public string PathToImage {
            get => _pathToImage;
            set {
                _pathToImage = value;
                OnPropertyChanged("PathToImage");
            } // set
        } // PathToImage

        // ансамбль конструкторов
        public CEO() : this("Unknown", "Unknown", "Unknown", @"../Images/ceo.jpg") { }

        public CEO(string surname, string name, string patronymic, string pathToImage = @"../Images/ceo.jpg") {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PathToImage = pathToImage;
        } // Person

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        } // OnPropertyChanged

    } // Person
} // PhoneBook
