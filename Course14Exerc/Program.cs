using Calculo.Entities;
using System.Globalization;

namespace Calculo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int nTaxPayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nTaxPayers; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                string iORc = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double aIcome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (iORc == "i")
                {
                    Console.Write("Health expenditures: ");
                    double hExpendi = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    TaxPayer payer = new Individual(hExpendi, name, aIcome);
                    taxPayers.Add(payer);
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int nEmploy = int.Parse(Console.ReadLine());

                    TaxPayer payer = new Company(nEmploy, name, aIcome);
                    taxPayers.Add(payer);
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            double sum = 0.0;
            foreach (TaxPayer t in taxPayers)
            {
                double tax = t.Tax();
                Console.WriteLine($"{t.Name}: $ {tax.ToString("F2", CultureInfo.InvariantCulture)}");
                sum += tax;
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}