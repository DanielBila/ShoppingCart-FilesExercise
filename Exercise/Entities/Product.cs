
using System.Globalization;

using Exercise.Entities.Exceptions;

namespace Exercise.Entities
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
      
        public Product(string csvProduct)
        {
            string[] values = csvProduct.Split(',');
            Name = values[0];
            Price = double.Parse(values[1], CultureInfo.InvariantCulture);
            Quantity = int.Parse(values[2], CultureInfo.InvariantCulture);
        }
        public double TotalPrice()
        {
            return Price * Quantity;
        }
        public override string ToString()
        {
            return $"{Name}, {TotalPrice().ToString("C2",new CultureInfo("en-us"))}";
        }

    }
}
