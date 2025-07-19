using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path: ");
            string path = Console.ReadLine().TrimEnd('\\');

            List<Product> products = new List<Product>();

            try
            {
                using (FileStream fs = File.OpenRead(Path.Combine(path,"source.csv")))
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        products.Add(new Product(sr.ReadLine()));
                    }
                }

                string outDir = Path.Combine(path, "out");
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                string targetFile = Path.Combine(outDir, "summary.csv");

                using (FileStream fs = new FileStream(targetFile, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Product product in products)
                    {
                        sw.WriteLine(product);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"IO Exception: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Format Exception: {e.Message}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Argument Null Exception: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Argument Exception: {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Unauthorized Access Exception: {e.Message}");
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }
        }
    }
}
