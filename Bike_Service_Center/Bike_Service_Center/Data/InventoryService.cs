using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bike_Service_Center.Data
{
    internal class InventoryService
    {
        private static void SaveAll(List<InventoryModel> items)
        {
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string GetAppinventoriesFilePath = Utils.GetAppinventoriesFilePath();
            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }
            //string path = "D:\\AD\\BikeSC\\item1.json";
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(GetAppinventoriesFilePath, json);
        }
        public static List<InventoryModel> WriteData(string item, int quantity, string approved_by, string taken_by)
        {

            //List<InventoryModel> items = new List<InventoryModel>();
            List<InventoryModel> items = ReadData();

            items.Add(
                new InventoryModel
                {
                    Item = item,
                    Quantity = quantity,
                    Approved_by = approved_by,
                    Taken_by = taken_by,
                }


            );

            SaveAll(items);
            DecreaseQuantity(item, quantity);
            return items;
        }
        public static List<InventoryModel> ReadData()
        {
            // string _filePath = "D:\\AD\\BikeSC\\item1.json";
            string appinventoriesFilePath = Utils.GetAppinventoriesFilePath();

            if (!File.Exists(appinventoriesFilePath))
            {
                return new List<InventoryModel>();
            }
            var json = File.ReadAllText(appinventoriesFilePath);
            //if (json == "")
            //{
            //    return new List<InventoryModel>();
            //}
            return JsonSerializer.Deserialize<List<InventoryModel>>(json);
        }
        public static void DecreaseQuantity(string ite, int quantity)
        {
            List<ItemModel> items = ItemService.ReadData();
            ItemModel itemToUpdate = items.FirstOrDefault(x => x.Name == ite);

            if (itemToUpdate == null)
            {
                throw new Exception("Item not found");

            }
            if (itemToUpdate.Quantity < quantity)
            {
                throw new InvalidOperationException($"Cannot remove quantity.");

            }

            itemToUpdate.Quantity -= quantity;
            ItemService.SaveAll(items);




        }

        //public static User GetById(Guid id)
        //{
        //    List<InventoryModel> items = ReadData();
        //    return items.FirstOrDefault(x => x.Id == id);
        //}
        public static void DeleteByUserId(Guid userId)
        {
            string _filePath = "D:\\AD\\BikeSC\\item1.json";
            //string todosFilePath = Utils.GetTodosFilePath(userId);
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
        public static List<InventoryModel> Delete(Guid id)
        {
            List<InventoryModel> items = ReadData();
            InventoryModel item = items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new Exception("item not found.");
            }

            //DeleteByUserId(id);
            items.Remove(item);
            SaveAll(items);
            return items;
        }
    }
}

        
    
