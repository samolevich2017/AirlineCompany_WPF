using FinalProject_Samolevich.HelperClassesTheme;
using FinalProject_Samolevich.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace FinalProject_Samolevich {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public ApplicationViewModel _viewModel;
        ListThemes themes = new ListThemes();
        FilesOperations fileO = new FilesOperations();
        const string fConfigPath = @"..\..\GivenTheme.json";
        public MainWindow() {
            InitializeComponent();
            _viewModel = new ApplicationViewModel(
                new WindowShowService(),
                new DialogService(),
                new JsonFileService()
            );

            DataContext = _viewModel;
        } // MainWindow

        // Событие загрузки окна
        private void Window_Loaded(object sender, RoutedEventArgs e) {
           StartTheme(fConfigPath); // устанавливаем тему из конфиг. файла
        } // Window_Loaded

        // Событие закрытия окна - убивает процесс приложения
        private void Window_Closed(object sender, System.EventArgs e) {
            Process thisProcess = new Process();
            thisProcess.Kill();
        } // Window_CLosed

        #region Работа с темами 
        private void btnThemeChange_Click(object sender, RoutedEventArgs e) {
            // если установлена темная темы, то ставим светлую
            if (themes.TitleTheme == "Dark Classic") {

                // инициализируем обьект класса темы
                themes = new ListThemes("Light Theme", new Uri(@"Themes/LightTheme.xaml", UriKind.Relative));

                // применяем тему
                themes.ApplyTheme();

                // сериализуем информацию о заданной теме в конфигурационный файл
                fileO.SerializationToJSON(fConfigPath, themes);

            } // иначе установлена светлая тема, и ставим темную
            else {

                // инициализируем обьект класса темы
                themes = new ListThemes("Dark Classic", new Uri(@"Themes/DarkTheme.xaml", UriKind.Relative));

                // применяем тему
                themes.ApplyTheme();

                // сериализуем информацию о заданной теме в конфигурационный файл
                fileO.SerializationToJSON(fConfigPath, themes);

            } // if/else
        } // 

        // Метод для применения стартовой темы, которая была выбрана
        // при прошлом использовании приложения
        public void StartTheme(string path) {

            // если файл с данными о теме существует
            if (File.Exists(path)) {

                // десериализуем данные о теме
                fileO.DeserializationFromJSON(path, ref themes);
                themes.ApplyTheme(); // применяем тему

            } // if

        } // StartTheme
        #endregion

    }
}
