using System;
using System.Globalization;
using System.Collections.Generic;
using Taxes.Entities;

namespace Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list= new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i<=n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or Company (i/c)? ");
                char ch=char.Parse(Console.ReadLine());

                if(ch=='i') 
                { 
                    Console.Write("Name: ");
                    string name=Console.ReadLine();
                    Console.Write("Anual Income: ");
                    double anualincome=double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.Write("Health Expenditures: ");
                    double healthexpenditures=double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                    list.Add(new Individual(name,anualincome,healthexpenditures));
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual Income: ");
                    double anualincome = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int employees=int.Parse(Console.ReadLine());

                    list.Add(new Company(name,anualincome,employees));

                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            double total = 0.0;
            foreach(TaxPayer taxes in list)
            {
                Console.WriteLine(taxes.Name +": R$ "+ taxes.Tax().ToString("F2",CultureInfo.InvariantCulture));
                total += taxes.Tax();
                
            }
            Console.WriteLine();
            Console.WriteLine($"TOTAL TAXES: R$ {total.ToString("F2",CultureInfo.InvariantCulture)}");
        }
    }
}