using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorFactory.Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            if (args.Length > 0)
            {
                var name = args[0];
                Console.WriteLine("privet " + name);
            }

            int chislo = 10;
            decimal dengi = 10.2m;
            double drobnoe1 = 10.2d;
            double drobnoe2 = 10.2d;
            var zero = drobnoe2 - drobnoe1;
            var zero1 = 0.0000000001d;
            DateTime startDate = DateTime.Now;
            DateTime endData = new DateTime(2033, 03, 08);
            var finishDate = startDate.AddYears(5);
            string stroka = "privet mir";
            char simvol = 'a';
            char simvol2 = stroka[0];
            bool istina = true;
            bool lozh = false;
            bool lozh2 = true && false;
            bool istina2 = true || false;

            var age = 33;
            var money = 20050.17m;
            var sovershennoletniy = age >= 18;
            var platezhesposobniy = money > 1000m;

            if (sovershennoletniy && platezhesposobniy)
            {
                Console.WriteLine("можно продать алкоголь");
            }
            else
            {
                Console.WriteLine("иди домой спать");
            }

            decimal dengi1 = 10.2m;
            decimal dengi2 = 10.3m;
            decimal dengi3 = 10.4m;

            Person maksim = new Person
            {
                Birthday = new DateTime(1991, 03, 08),
                Name = "Maksim",
                IndividualTaxpayerNumber = 912931293,
                MoneyBalance = 217.90m
            };
            Person andrey = new Person();
            andrey.IndividualTaxpayerNumber = 1123123;
            andrey.Name = "Andrey";
            andrey.Birthday = new DateTime(2012, 05, 18);
            andrey.MoneyBalance = 50;

            string[] names = new string[10];
            DateTime[] birthday = new DateTime[10];
            decimal[] moneyBalance = new decimal[10];

            int count = 15;
            int[] chisla = new int[count];
            chisla[0] = 10;
            chisla[1] = 2;
            chisla[2] = 3;
            Console.WriteLine(chisla[1]);

            for (int i = 0; i < count; i++)
            {
                chisla[i] = i;
            }

            for (int i = 0; i < count; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Console.Write(chisla[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.Write(chisla[count - i - 1] + " ");
            }
            Console.WriteLine();

            int j = 0;
            while (j < count)
            {
                Console.Write((chisla[j] - 2) + " ");
                j++;
            }
            Console.WriteLine();

            int index = 0;
            foreach (int a22 in chisla)
            {
                if (index == 5)
                {
                    break;
                }
                Console.Write((a22 + 5) + " ");
                index++;
            }
            Console.WriteLine();

            int a = 3;
            int b = -14;
            int c = 5;
            double decriminant = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine("decriminant: " + decriminant);

            if (decriminant > 0)
            {
                double x1 = (-b - Math.Sqrt(decriminant)) / (2 * a);
                double x2 = (-b + Math.Sqrt(decriminant)) / (2 * a);
                Console.WriteLine("koren1: " + x1);
                Console.WriteLine("koren2: " + x2);
            }
            else if (decriminant == 0)
            {
                double x1 = -b / (2 * a);
                Console.WriteLine("koren: " + x1);
            }
            else
            {
                Console.WriteLine("korney net!");
            }

            // 1) создать массив на 20 элементов
            // 2) заполнить их числами от 5 до 25
            // 3) вывести на экран 10 чисел с 7 по 17
            // 4) вывести на экран все числа, которые делятся на 2 без остатка (2 4 6 8 10)
            // var ostatok = 8 % 2; / 0 ; 9 % 2 / 1
        }
    }

    /// <summary>
    /// Описание человека.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public int IndividualTaxpayerNumber { get; set; }

        public decimal MoneyBalance { get; set; }
    }
}
