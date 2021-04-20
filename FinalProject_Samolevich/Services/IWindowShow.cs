using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Samolevich.Services {

    // Интерфейс для открытия новых окон
    public interface IWindowShow {

        void OpenWindowManagement(); // открытие окна управления авиакомпаниями
        void OpenWindowShop(); // открытие окна магазина самолетов
        void OpenWindowDetails(); // открытие окна для просмотра подробной информации о самолете
        void OpenWindowSelect(); // открытие окна для отбора по диапазону потребления горючего
        void OpenAboutProgramWindow(); // открытие окна с информацией о программе

    } // IWindowShow 
} // FinalProject_Samolevich.Services
