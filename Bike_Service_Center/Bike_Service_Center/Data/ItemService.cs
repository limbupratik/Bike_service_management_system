
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bike_Service_Center.Data
    {
        internal class ItemService
        {
            public static void SaveAll(List<ItemModel> items)
            {
                string appDataDirectoryPath = Utils.GetAppDirectoryPath();
                string GetAppitemsFilePath = Utils.GetAppitemsFilePath();
                if (!Directory.Exists(appDataDirectoryPath))
                {
                    Directory.CreateDirectory(appDataDirectoryPath);
                }
                
                var json = JsonSerializer.Serialize(items);
                File.WriteAllText(GetAppitemsFilePath, json);
            }
            public static List<ItemModel> WriteData(string name, string description, int quantity, string price)
            {

                
                List<ItemModel> items = ReadData();
                items.Add(
                    new ItemModel
                    {
                        Name = name,
                        Description = description,
                        Quantity = quantity,
                        Price = price
                    }
                );
                SaveAll(items);
                return items;
            }
            public static List<ItemModel> ReadData()
            {
                
                string appitemsFilePath = Utils.GetAppitemsFilePath();

                if (!File.Exists(appitemsFilePath))
                {
                    return new List<ItemModel>();
                }
                var json = File.ReadAllText(appitemsFilePath);
              
                return JsonSerializer.Deserialize<List<ItemModel>>(json);
            }
            public static List<ItemModel> Update(Guid id, string name, string address, int quantity, string email)
            {
                List<ItemModel> items = ReadData();
                ItemModel itemToUpdate = items.FirstOrDefault(x => x.Id == id);

                if (itemToUpdate == null)
                {
                    throw new Exception("Todo not found.");
                }

                itemToUpdate.Name = name;
                itemToUpdate.Description = address;
                itemToUpdate.Quantity = quantity;
                itemToUpdate.Price = email;
                SaveAll(items);
                return items;
            }
          
            public static void DeleteByUserId(Guid userId)
            {
                string _filePath = "D:\\AD\\BikeSC\\item1.json";
               
                if (File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }
            }
            public static List<ItemModel> Delete(Guid id)
            {
                List<ItemModel> items = ReadData();
                ItemModel item = items.FirstOrDefault(x => x.Id == id);

                if (item == null)
                {
                    throw new Exception("item not found.");
                }               
                items.Remove(item);
                SaveAll(items);
            
            return items;
            }
        public static ItemModel GetById(Guid id)
        {
            List<ItemModel> items = ReadData();
            return items.FirstOrDefault(x => x.Id == id);
        }
        public static List<ItemModel> Update(string name, DateTime date)
        {
            List<ItemModel> items = ReadData();
            ItemModel itemToUpdate = items.FirstOrDefault(item => item.Name == name);



            itemToUpdate.Date = date;
            SaveAll(items);


            return items;
        }
    }
    }


