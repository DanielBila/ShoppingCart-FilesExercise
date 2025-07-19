using ShoppingCart.Entities;
using ShoppingCart.Services;
using System.Globalization;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("enter the location of the csv file:");
                string path = Console.ReadLine().TrimEnd('\\');
                CsvDirectoryService service = new CsvDirectoryService(path);
                Console.WriteLine("enter the quantity of the product to be cataloged: ");
                int cataloged = int.Parse(Console.ReadLine());
                for (int i = 0; i < cataloged; i++)
                {
                    Console.WriteLine("enter the product name: ");
                    string product = Console.ReadLine();
                    Console.WriteLine("enter the price of the product: ");
                    double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.WriteLine("enter the quantity of the product: ");
                    int quantity = int.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    service.AddProduct(product, price, quantity);
                }
                Console.Clear();
                Console.WriteLine("Quantidade Nome Preço");
                foreach (Shopping item in service.Products)
                {
                    Console.WriteLine(item);
                }
            }
            catch (IOException m)
            {
                Console.WriteLine(m.Message);             
            }
            catch (ApplicationException m)
            {
                Console.WriteLine(m.Message);
            }
            catch (FormatException m)
            {
                Console.WriteLine(m.Message);
            }
            catch (ArgumentNullException m)
            {
                Console.WriteLine(m.Message);
            }
            catch (ArgumentException m)
            {
                Console.WriteLine(m.Message);
            }           
            catch (UnauthorizedAccessException m)
            {
                Console.WriteLine(m.Message);
            }

        }
    }
}
