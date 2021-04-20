using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace FinalProject_Samolevich.HelperClassesTheme {

    // Класс - Список тем
    // Для сериализации состояния приложения
    [DataContract]
    public class ListThemes {

        // название темы
        [DataMember]
        public string TitleTheme { get; set; }

        // Uri - идентификатор ресурса темы
        [DataMember]
        public Uri Uris { get; set; }

        // конструктор по умолчанию
        public ListThemes() { }

        // конструктор с параметрами
        public ListThemes(string theme, Uri uriTheme) {
            TitleTheme = theme;
            Uris = uriTheme;
        } // ListTheme

        // метод применяющий тему к окну
        public void ApplyTheme() {

            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(Uris) as ResourceDictionary;

            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();

            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        } // ApplyTheme

    } // ListThemes
} // namespace Exhibition
