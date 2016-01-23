using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;


namespace MySQLbase
{
    public class ItemsOP
    {
        public static Item GetItemById(int Id) {
            Item item = new Item();
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(
                    GeneralSettings.ConnectionString, Queries.GetItemById(Id)))
                {

                    reader.Read();
                    item.Id = Id;
                    item.Name = reader.GetString(1);
                    item.Price = reader.GetDecimal(2);
                    item.CatId = reader.GetInt32(3);
                    item.PrinterId = reader.GetInt32(4);
                }
                return item;

            }
            catch (Exception IGIBI)
            {
                throw new Exception("Exception occured on ItemsOP.GetItemById" +
                    "\nError Message: " + IGIBI.Message);
            }
        }

        public static string GetPrinterCodeName(int ItemId)
        {
            string PrinterCodeName=string.Empty;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(
                GeneralSettings.ConnectionString, Queries.GetPrinterCodeName(ItemId)))
            {
                reader.Read();
                PrinterCodeName = reader.GetString(0);
            }
            return PrinterCodeName;
        }

        public static IEnumerable GetAllItems()
        {
            List<Item> items = new List<Item>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(
                GeneralSettings.ConnectionString, Queries.GetAllItem()))
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Item item = new Item();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Price = reader.GetDecimal(2);
                        item.CatId = reader.GetInt32(3);
                        item.PrinterId = reader.GetInt32(4);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static IEnumerable GetItemsByCat(int Id)
        {
            List<Item> items = new List<Item>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(
                GeneralSettings.ConnectionString, Queries.GetItemByCat(Id))) {

                if (reader.HasRows) {
                    while (reader.Read()) {
                        Item item = new Item();
                        item.Id = Id;
                        item.Name = reader.GetString(1);
                        item.Price = reader.GetDecimal(2);
                        item.CatId = reader.GetInt32(3);
                        item.PrinterId = reader.GetInt32(4);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static int InsertItem(Item item)
        {
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("name", item.Name));
            parms.Add(new MySqlParameter("price", item.Price));
            parms.Add(new MySqlParameter("catid", item.CatId));
            parms.Add(new MySqlParameter("printerid", item.PrinterId));
            
            return MySqlHelper.ExecuteNonQuery(
                GeneralSettings.ConnectionString, Queries.InsertItem(), parms.ToArray());
        }

        public static int UpdateItem(Item item)
        {
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("itemid", item.Id));
            parms.Add(new MySqlParameter("name", item.Name));
            parms.Add(new MySqlParameter("price", item.Price));
            parms.Add(new MySqlParameter("catid", item.CatId));
            parms.Add(new MySqlParameter("printerid", item.PrinterId));
            
            return MySqlHelper.ExecuteNonQuery(
                GeneralSettings.ConnectionString, Queries.UpdateItem(), parms.ToArray());
        }
        
    }
}

