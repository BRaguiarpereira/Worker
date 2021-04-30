using System;
using Trabalhador.Entities.Enums;
using Trabalhador.Entities;
using System.Globalization;
namespace Trabalhador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter department name : ");
            string depName = Console.ReadLine();
            Console.Write(" Enter worker date : ");
            Console.Write(" Name : ");
            string name = Console.ReadLine();
            Console.Write(" Level : ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write(" Base Salary : ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Instanciando o objeto departamento
            Department dept = new Department(depName);

            // Instanciando o objeto worker passando por parametro :
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("how many contracts to this worker ? ");

            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract date : ");
                Console.Write("Date (DD/MM/YYYY)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valeu per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Duration hors: ");
                int hours = int.Parse(Console.ReadLine());
                // Intanciando o contrato dentro do for 
                HourContract contract = new HourContract(date, valuePerHour, hours);
                // Adicionar os contratos no worker já instaciado lá em cima 
                worker.AddContract(contract);
            }
            Console.WriteLine("Enter month and year to calculate income : ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: "+ worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for: "+ monthAndYear + ": "+worker.Income(month,year).ToString("F2",CultureInfo.InvariantCulture));



        }
    }
}
