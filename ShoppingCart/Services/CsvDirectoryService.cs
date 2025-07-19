using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    internal class CsvDirectoryService
    {
        public string Path { get; set; }
        public List<Shopping> Products = new List<Shopping>();

        public CsvDirectoryService(string path)
        {
            
            Path = path + @"\out";
            // Check if the directory exists, if not create it
            if (Directory.Exists(Path))
            {
                Path = Path + @"\summary.csv";
                // Check if the file exists, if not create it
                if (File.Exists(Path))
                {
                    List<string> lines = File.ReadAllLines(Path).ToList();
                    // Iterate through each line in the file and parse the data
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts.Length == 3)
                        {
                            string product = parts[0];
                            double price = double.Parse(parts[1]);
                            int quantity = int.Parse(parts[2]);
                            Products.Add(new Shopping(product, price, quantity));
                        }
                    }
                }
                else
                {
                    using FileStream fs = File.Create(Path); 
                }
            }
            else
            {
                Directory.CreateDirectory(Path);
                Path = Path + @"\summary.csv";
                if (File.Exists(Path))
                {
                    List<string> lines = File.ReadAllLines(Path).ToList();
                    for (int i = 0; i > lines.Count; i++)
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts.Length == 3)
                        {
                            string product = parts[0];
                            double price = double.Parse(parts[1]);
                            int quantity = int.Parse(parts[2]);
                            Products.Add(new Shopping(product, price, quantity));
                        }
                    }
                }
                else
                {
                    using FileStream fs = File.Create(Path); 
                }
            }                  
        }
        public void AddProduct(string product, double price, int quantity)
        {
            Products.Add(new Shopping(product, price, quantity));
            using (FileStream fs = File.Open(Path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs)) 
                {
                    sw.WriteLine($"{product},{price},{quantity}"); // Write the new product to the CSV file
                }
            }
        }
    }
}
