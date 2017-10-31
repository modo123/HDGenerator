using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator
{
    class Utilities
    {
        
        public static Tuple<int, int, int> GeneratedDate(Tuple<int, int, int> date1, Tuple<int, int, int> date2)
        {
         
            Random _random = new Random(); // ToDo - rand nie losuje :(
            
            var rok = _random.Next(date1.Item1, date2.Item1);
            ////////////////////////////////////////////////////////
            int miesiac;
            if (rok == date2.Item1)
            {
                if (rok == date1.Item1)
                {
                    miesiac = _random.Next(date1.Item2, date2.Item2);
                }
                else
                {
                    miesiac = _random.Next(1, date2.Item2);
                }
            }
            else if (rok == date1.Item1)
            {
                miesiac = _random.Next(date1.Item2, 12);
            }
            else
            {
                miesiac = _random.Next(1, 12);
            }
            ////////////////////////////////////////////////////////
            int dzien;
            if (rok == date2.Item1 && miesiac == date2.Item2)
            {
                if (rok == date1.Item1 && miesiac == date1.Item2)
                {
                    dzien = _random.Next(date1.Item3, date2.Item3);
                }
                else
                {
                    dzien = _random.Next(1, date2.Item3);
                }
            }
            else if (rok == date1.Item1 && miesiac == date1.Item2)
            {
                dzien = _random.Next(date1.Item3, DateTime.DaysInMonth(rok, miesiac));
            }
            else
            {
                dzien = _random.Next(1, DateTime.DaysInMonth(rok, miesiac));
            }

            return Tuple.Create(rok, miesiac, dzien);
        }

        public static long PESELGenerator()
        {
            Random _random = new Random();
            int year = _random.Next(62, 92);
            int month = _random.Next(1, 12);
            int day;
            if(month == 2)
                day = _random.Next(1,28);
            else 
                day = _random.Next(1,31);

            int rest = _random.Next(10000, 99999);
            string pesel;
            if (month < 10)
                pesel = year.ToString() + "0" + month.ToString();
            else
                pesel = year.ToString() + month.ToString();

            if (day < 10)
                pesel = pesel + "0" + day.ToString() + rest.ToString();
            else
                pesel = pesel + day.ToString() + rest.ToString();

            return long.Parse(pesel);
        }

        public static string NIPGenerator()
        {
            string NIP;
            Random _random = new Random();
            int part1 = _random.Next(100, 999);
            int part2 = _random.Next(10, 99);
            int part3 = _random.Next(10, 99);
            int part4 = _random.Next(100, 999);

            NIP = part1.ToString() + "-" + part2.ToString() + "-" + part3.ToString() + "-" + part4.ToString();

            return NIP;
        }
    }
}
