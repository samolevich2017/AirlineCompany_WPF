using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Samolevich.HelperClassesTheme {

    // Класс хранящий в себе обощенные методы для работы с файлами
    class FilesOperations {

        // Сериализация  в файл формата JSON
        public void SerializationToJSON<T>(string path, T obj) {

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ListThemes));

            using (FileStream fs = new FileStream(path, FileMode.Create)) {
                jsonFormatter.WriteObject(fs, obj);
            } // using

        } // SerializationToJSON

        // Десериализация коллекций из файла формата JSON
        public void DeserializationFromJSON<T>(string path, ref T obj) {

            if (File.Exists(path)) {

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ListThemes));

                using (FileStream fs = new FileStream(path, FileMode.Open)) {

                    obj = (T)jsonFormatter.ReadObject(fs);

                } // using

            } // if

        } // DeserializationFromJSON

    } // class FilesOperations
} // namespace Exhibition
