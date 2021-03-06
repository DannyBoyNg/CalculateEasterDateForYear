﻿using System;
using System.Collections.Generic;

namespace CalculateEasterDateForYear
{
    public class Easter
    {
        static Dictionary<int, DateTime> cache = new Dictionary<int, DateTime>();

        public static DateTime GetDateForYear(int? yearArg = null)
        {
            int year = (yearArg == null) ? DateTime.Now.Year : year = yearArg.Value;
            if (cache.ContainsKey(year)) return cache[year];
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));

            day = i - ((year + year / 4 + i + 2 - c + c / 4) % 7) + 28;
            month = 3;
            if (day > 31)
            {
                month++;
                day -= 31;
            }

            var result = new DateTime(year, month, day);
            cache.Add(year, result);
            return result;
        }
    }
}
