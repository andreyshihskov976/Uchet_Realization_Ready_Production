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

        public string Select_Sklad = $@"SELECT ID_Sklada AS 'ID Склада', Name AS 'Наименование склада' FROM sklad;";

        public string Select_Sklad_ComboBox = $@"SELECT Name AS 'Наименование склада' FROM sklad;";

        public string Select_Sklad_ID = $@"SELECT ID_Sklada AS 'ID Склада'FROM sklad WHERE Name = @Value1 ;";

        public string Select_Product = $@"SELECT product.ID_Product AS 'ID Продукции', product.Name AS 'Наименование продукции',product.Ed_Izm AS 'Единицы измерения', sklad.Name AS 'Хранится на складе'
FROM product INNER JOIN sklad ON product.ID_Sklada = sklad.ID_Sklada;";

        public string Select_Organizacii = $@"SELECT ID_Organizacii AS 'ID Заказчика', Name AS 'Наименование организации заказчика', Adress AS 'Адрес доставки'
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



        //Insert

        public string Insert_Sklad = $@"INSERT INTO sklad (Name) VALUES (@Value1);";

        public string Insert_Product = $@"INSERT INTO product (ID_Sklada, Name, Ed_Izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Organizacii = $@"INSERT INTO organizacii (Name, Adress) VALUES (@Value1, @Value2);";

        //Insert



        //Update

        public string Update_Sklad = $@"UPDATE sklad SET Name = @Value1 WHERE ID_Sklada = @ID;";

        public string Update_Product = $@"UPDATE product SET ID_Sklada= @Value1, Name= @Value2, Ed_Izm = @Value3 WHERE ID_Product = @ID;";

        public string Update_Organizacii = $@"UPDATE organizacii SET Name = @Value1, Adress = @Value2 WHERE ID_Organizacii = @ID;";

        //Update



        //Delete

        public string Delete_Sklad = $@"DELETE FROM sklad WHERE ID_Sklada = @ID;";

        public string Delete_Product = $@"DELETE FROM product WHERE ID_Product = @ID;";

        public string Delete_Organizacii = $@"DELETE FROM organizacii WHERE ID_Organizacii = @ID;";

        //Delete
    }
}
