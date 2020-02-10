using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production
{
    public class MySqlQueries
    {
        //Select

        public string Select_Sklad = $@"SELECT Name AS 'Наименование склада' FROM sklad;";

        public string Select_Product = $@"SELECT product.Name AS 'Наименование продукции',product.Ed_Izm AS 'Единицы измерения', sklad.Name AS 'Хранится на складе'
FROM product INNER JOIN sklad ON product.ID_Sklada = sklad.ID_Sklada;";

        public string Select_Organizacii = $@"SELECT Name AS 'Наименование организации заказчика', Adress AS 'Адрес доставки'
FROM organizacii;";

        public string Select_Zayavka = $@"SELECT zayavka.ID_Zayavki AS 'Заявка, №', sklad.Name AS 'Отгрузка со склада', zayavka.Date AS 'Дата отгрузки'
FROM zayavka INNER JOIN sklad ON zayavka.ID_Sklada = sklad.ID_Sklada;";

        public string Select_All_Zakaz = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', organizacii.Name AS 'Наименование организации заказчика', zakaz.Date AS 'Дата заказа'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii;";

        public string Select_Done_Zakaz = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', organizacii.Name AS 'Наименование организации заказчика', zakaz.Date AS 'Дата заказа'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
WHERE zakaz.Identify = 'Отгружен';";

        public string Select_Wait_Zakaz = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', organizacii.Name AS 'Наименование организации заказчика', zakaz.Date AS 'Дата заказа'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
WHERE zakaz.Identify = 'Ожидает отгрузки';";
        //Select
    }
}
