using FinalProject_Samolevich.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Samolevich.Services {
    public interface IFileService {
        ObservableCollection<AirlineCompany> Load(string filename);    // загрузить коллекцию из файла
        void Save(string filename, ObservableCollection<AirlineCompany> phonesList);   // сохранить коллекцию в файле
        void Copy(string filePath); // копировать файл в папку проекта

    } // IFileService
} // FinalProject_Samolevich.Services 
