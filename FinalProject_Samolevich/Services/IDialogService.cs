using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Samolevich.Services {
    public interface IDialogService {

        void ShowMessage(string message);   // показ сообщения

        bool OpenFileDialog();  // открытие файла
        bool SaveFileDialog();  // сохранение файла

        string FilePath { get; set; }   // путь к выбранному файлу

    } // IDialogService 
} // FinalProject_Samolevich.Services 
