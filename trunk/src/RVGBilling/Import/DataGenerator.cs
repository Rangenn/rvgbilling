using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVGBilling.Import
{
    /// <summary>
    /// Генератор двумерных массивов строк данных
    /// </summary>
    public class DataGenerator
    {
        Random gen;
        /// <summary>
        /// Сгенерировать count случайных звонков для списка номеров numbersfrom, с которых звонили.
        /// Маски MaskMin и MaskMaxдолжны быть одинаковой длины!!!
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public string[][] generateCalls(int count, string[] numbersfrom, string MaskMin, string MaskMax)
        {
            
            string[][] res = new string[count][];
            if (MaskMax.Length != MaskMin.Length) return null;
            gen = new Random();
            int maskmin = Convert.ToInt32(MaskMin);
            int maskmax = Convert.ToInt32(MaskMax);
            int r;
            for (int i = 0; i < count; i++)
            {
                res[i] = new string[4];
                res[i][0] = numbersfrom[gen.Next(numbersfrom.Length - 1)];
                //рандом длиной (10 - длина маски)
                r = gen.Next() % Convert.ToInt32((Math.Pow(10, 10 - MaskMax.Length)));
                //случайная маска из диапазона + r
                res[i][1] = (gen.Next(maskmax - maskmin) + maskmin).ToString() + r.ToString();
                res[i][2] = DateTime.Now.ToString();
                res[i][3] = gen.Next(600).ToString(); //0..10 мин
            }
                return res;
        }
        /// <summary>
        /// Сгенерировать count тарифов с масками MaskFrom..MaskTo
        /// </summary>
        /// <param name="count"></param>
        /// <param name="ratecount"></param>
        /// <returns></returns>
        public string[][] generateRates(int count, int MaskFrom, int MaskTo)
        {
            int tmp;
            int pricesperrate = MaskTo - MaskFrom + 1;
            string[][] res = new string[count * pricesperrate][];
            gen = new Random();
            string[] ratenames = new string[count];
            for (int i = 0; i < count; i++)
                ratenames[i] = gen.Next().ToString();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < pricesperrate; j++)
                {
                    tmp = i * pricesperrate + j;
                    res[tmp] = new string[3];
                    res[tmp][0] = ratenames[i];
                    res[tmp][1] = (MaskFrom + j).ToString();
                    res[tmp][2] = (gen.NextDouble() * 10).ToString(); //0..10
                }
            }
            return res;
        }

        /// <summary>
        /// Сгенерировать тариф
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="MaskFrom"></param>
        /// <param name="MaskTo"></param>
        /// <returns></returns>
        public string[][] generateRate(string Name, int MaskFrom, int MaskTo)
        {
            int pricesperrate = MaskTo - MaskFrom + 1;
            string[][] res = new string[pricesperrate][];
            gen = new Random();
                for (int j = 0; j < pricesperrate; j++)
                {
                    res[j] = new string[3];
                    res[j][0] = Name;
                    res[j][1] = (MaskFrom + j).ToString();
                    res[j][2] = (Math.Round(gen.NextDouble() * 10, 3)).ToString(); //0..10
                }
            
            return res;
        }
    }
}
