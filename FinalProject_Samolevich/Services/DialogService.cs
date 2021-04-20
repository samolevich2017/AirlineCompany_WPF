using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject_Samolevich.Services {
    public class DialogService : IDialogService {
        public string FilePath { get; set; }

        // диалог открытия файла
        public bool OpenFileDialog() {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true) {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;

        } // OpenFileDialog

        // диалог сохранения файла
        public bool SaveFileDialog() {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true) {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;

        } // SaveFileDialog

        // вывод сообщения
        public void ShowMessage(string message) {
            MessageBox.Show(message, "Работа с файлом", MessageBoxButton.OK, MessageBoxImage.Information);
        } // ShowMessage

    } // DialogService
} // FinalProject_Samolevich.Services 
