using System;
using System.Collections.Generic;

namespace DZ_Generic_Collections
{
    internal class Product : ICloneable, IComparable<Product>
    {
        public string Name { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public Product(string name, DateTime productionDate, decimal price) { Name = name; ProductionDate = productionDate; Price = price; }
        public object Clone() { return new Product(Name, ProductionDate, Price); }
        public int CompareTo(Product other) { return Name.CompareTo(other.Name); }
        public override string ToString() { return Name + "; дата: " + ProductionDate.ToShortDateString() + "; цена: " + Price + " грн"; }
    }
    internal class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product first, Product second) { return first.Name.CompareTo(second.Name); }
    }
    internal class ProductDateComparer : IComparer<Product>
    {
        public int Compare(Product first, Product second) { return first.ProductionDate.CompareTo(second.ProductionDate); }
    }
    internal class ProductPriceComparer : IComparer<Product>
    {
        public int Compare(Product first, Product second) { return first.Price.CompareTo(second.Price); }
    }
}
