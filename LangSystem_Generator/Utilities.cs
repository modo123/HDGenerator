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
            Random _random = new Random();

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
    }
}
