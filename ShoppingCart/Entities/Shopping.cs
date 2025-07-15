using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Entities.Exceptions;

namespace ShoppingCart.Entities
{
    internal class Shopping
    {
        public string Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Shopping(string product, double price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;

            //Execute validations
            if (quantity == 0)
            {
                throw new DomainExceptionEntities("Quantity cannot be zero.");
            }
            if(product == null)
            {
                throw new DomainExceptionEntities("Product cannot be null.");
            }
            if(price < 0)
            {
                throw new DomainExceptionEntities("Price cannot be negative.");
            }
        }
        public override string ToString()
        {
            return $"{Quantity}: {Product} {Price.ToString("C2", new CultureInfo("en-US"))}";
        }

    }
}
