using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface ILogic
    {
        //public List<Beverage> Beverages { get; set; }
        public void AddBeer(string name, double alcohol, BeerType type, string? country, int? year, int? ibu);
        public void AddWine(string name, double alcohol, WineType type, string? country, int? year, string? grape);
        public List<Beverage> GetBeverages();
    }
}
