using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    public class JsonBeverage
    {
        public string Class { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Alcohol { get; set; }
        public string Country { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty;
        public int IBU { get; set; }
        public string Grape { get; set; } = string.Empty;

        public JsonBeverage(string beverageType, string name, double alcohol, string? country, int? year, string type, int? iBU, string? grape)
        {
            Class = beverageType;
            Name = name;
            Alcohol = alcohol;
            Country = country;
            Year = year;
            Type = type;
            IBU = iBU;
            Grape = grape;
        }
    }
    internal class JsonStorage: IStorage
    {
    
  
        public void SaveAllBeverages(List<Beverage> beverages)
        {
            throw new NotImplementedException();
        }



        List<Beverage> IStorage.LoadAllBeverages()
        {
            throw new NotImplementedException();
        }
    }
   //JsonSerialized
}
