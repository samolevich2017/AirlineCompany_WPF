using FinalProject_Samolevich.PageShopSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinalProject_Samolevich.Services {
    class PageShowService : IPageShow {

        // Отобразить страничку раздела для продаж
        Page sectionSales;
        public Page ShowPageSales() {
            sectionSales = new PageSalesSection();
            return sectionSales;
        } // ShowPageSales

        // Отобразить страничку раздела для покупок
        Page sectionPurchases;
        public Page ShowPagePurchases() {
            sectionPurchases = new PagePurchasesSection();
            return sectionPurchases;
        } // ShowPagePurchases

    } // PageShowService
} // FinalProject_Samolevich.Services
