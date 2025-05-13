using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface IStorage
    {
        public void SaveAllBeverages(List<Beverage> beverages);
        public List<Beverage> LoadAllBeverages();
    }
}
