using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Wine : Beverage
    {
        public string? Grape { get; set; }
        public required WineType Type { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} - {Type} - Grape: {Grape}";
        }

        public override string CsvFormat()
        {
            return $"Wine,{base.CsvFormat()},{Type},,{Grape}";
        }
    }

    public enum WineType
    {
        Red,
        White,
        Rose,
        Sparkling,
        Dessert
    }
}