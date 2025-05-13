using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Beer: Beverage
    {
        public required BeerType Type { get; set; }
        public int IBU { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} - {Type} - IBU: {IBU}";
        }

        public override string CsvFormat()
        {
            return $"Beer,{base.CsvFormat()},{Type},{IBU},";
        }

    }

    public enum BeerType
    {
        Lager,
        Ale,
        Stout,
        Porter,
        IPA,
        Wheat,
        Pilsner,
        Sour,
        BrownAle,
        AmberAle
    }

}
