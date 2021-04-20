using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject_Samolevich.Services {

    public class WindowShowService : IWindowShow {

        // Открыть окно для управления авиакомпаниями
        AirlineManagementWindow window;
        public void OpenWindowManagement() {
            window = new AirlineManagementWindow();
            window.ShowDialog();
        } // OpenWindowManagement

        // Открыть окно магазина самолетов
        ShopWindow shopWindow;
        public void OpenWindowShop() {
            shopWindow = new ShopWindow();
            shopWindow.ShowDialog();
        } // OpenWindowShop

        // Открыть окно для просмотра подробной информации о самолете
        AirplaneWindow windowAir;
        public void OpenWindowDetails() {
            windowAir = new AirplaneWindow();
            windowAir.ShowDialog();
        } // OpenWindowDetails

        // Открыть окно для отбора по диапазону потребления горючего
        SelectByDiapWindow windowSelect;
        public void OpenWindowSelect() {
            windowSelect = new SelectByDiapWindow();
            windowSelect.ShowDialog();
        } // OpenWindowSelect

        // Открыть окно с информацией о программе
        AboutProgramWindow apw;
        public void OpenAboutProgramWindow() {
            apw = new AboutProgramWindow();
            apw.ShowDialog();
        } // OpenAboutProgramWindow

    } // WindowShowService
} // FinalProject_Samolevich.Services
