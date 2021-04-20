using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FinalProject_Samolevich.Models;

namespace FinalProject_Samolevich.Services {
    public class JsonFileService : IFileService {

        // загрузка коллекции из файла - десериализация
        public ObservableCollection<AirlineCompany> Load(string filename) {

            ObservableCollection<AirlineCompany> companies;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<AirlineCompany>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate)) {
                companies = jsonFormatter.ReadObject(fs) as ObservableCollection<AirlineCompany>;
            } // using

            return companies;
        } // Load

        // сохранение коллекции в файл - сериализация
        public void Save(string filename, ObservableCollection<AirlineCompany> phonesList) {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<AirlineCompany>));
            using (FileStream fs = new FileStream(filename, FileMode.Create)) {
                jsonFormatter.WriteObject(fs, phonesList);
            } // using
        } // Save

        // копирование файла в папку проекта (для загрузки фото)
        public void Copy(string filePath) {
           
            FileInfo fi = new FileInfo(filePath);
            string filePathProject = @"../../AirplanesImages/1.jpg";
            if (fi.Exists) {
                fi.CopyTo(filePathProject, true);
            } // if
            
        }

    } // JsonFileService
} // FinalProject_Samolevich.Services
