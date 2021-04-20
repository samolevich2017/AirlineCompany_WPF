using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProject_Samolevich.Services {

    // Интерфейс для отображения страниц
    public interface IPageShow {
        Page ShowPageSales(); // метод для открытия страницы в магазине "Раздел для продаж"
        Page ShowPagePurchases(); // метод для открытия страницы в магазине "Раздел для покупок"

    } // IPageShow
} // FinalProject_Samolevich.Services
