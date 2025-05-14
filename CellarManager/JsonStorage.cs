using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class JsonBeverage
    {
        public string Class { get; set; } 
        public string Name { get; set; } 
        public double Alcohol { get; set; }
        public string Country { get; set; } 
        public int Year { get; set; }
        public string Type { get; set; }
        public int? IBU { get; set; }
        public string? Grape { get; set; } = string.Empty;

        public JsonBeverage(string beverageType, string name, double alcohol, string country, int year, string type, int? iBU, string? grape)
        {
            Class = beverageType;
            Name = name;
            Alcohol = alcohol;
            Country = country;
            Year = year;
            Type = type;
            IBU = iBU??null;
            Grape = grape;
        }
    }
    internal class JsonStorage: IStorage
    {
    
  
        public void SaveAllBeverages(List<Beverage> beverages)
        {
            List<JsonBeverage> builder = new List<JsonBeverage>();

            
            foreach (var bev in beverages)
            {
                var classObj = bev.GetType().Name;
                if (classObj == "Wine")
                {
                    var newBev = (Wine)bev;
                    var wineType = newBev.Type.ToString();

                    JsonBeverage jsonBev = new JsonBeverage(classObj, newBev.Name, newBev.Alcohol, newBev.Country, newBev.Year, wineType , null, newBev.Grape);
                    builder.Add(jsonBev);
                }
                else if (classObj == "Beer")
                {
                    var newBev = (Beer)bev;
                    var beerType = newBev.Type.ToString();

                    JsonBeverage jsonBev = new JsonBeverage(classObj, newBev.Name, newBev.Alcohol, null, newBev.Year, beerType, newBev.IBU, null);
                    builder.Add(jsonBev);
                } else
                {
                    throw new Exception($"{bev.Name} is not formatted correctly");
                }
            }
            var json = System.Text.Json.JsonSerializer.Serialize( builder );
            File.WriteAllText("beverages.json", json);
        }

        List<Beverage> IStorage.LoadAllBeverages()
        {
            var beverages = new List<Beverage>();
            try
            {
                var json = File.ReadAllText("beverages.json");
                List<JsonBeverage> list = System.Text.Json.JsonSerializer.Deserialize<List<JsonBeverage>>(json)?? [];
                foreach (var beverage in list) {
                    if (beverage.Class == "Beer")
                    {
                        var beer = new Beer
                        {
                            Name = beverage.Name,
                            Alcohol = beverage.Alcohol,
                            Country = beverage.Country,
                            Year = beverage.Year,
                            Type = (BeerType)Enum.Parse(typeof(BeerType), beverage.Type),
                            IBU = (int)beverage.IBU
                        };
                        beverages.Add(beer);
                    }
                    else if (beverage.Class == "Wine")
                    {
                        var wine = new Wine
                        {
                            Name = beverage.Name,
                            Alcohol = beverage.Alcohol,
                            Country = beverage.Country,
                            Year = beverage.Year,
                            Type = (WineType)Enum.Parse(typeof(WineType), beverage.Type),
                            Grape = beverage.Grape
                        };
                        beverages.Add(wine);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading JSON file. Please check the file format.");
            }

            return beverages;
        }
    }
   //JsonSerialized
}
