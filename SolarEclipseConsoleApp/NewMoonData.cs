using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarEclipseConsoleApp
{
    internal class NewMoonData
    {
        // All new moon dates from 2022 thru A035. Source: timeanddate.com
        private static readonly List<DateTime> _newMoons = new()
        {
            new DateTime(2022, 1, 2),
            new DateTime(2022, 2, 1),
            new DateTime(2022, 3, 2),
            new DateTime(2022, 4, 1),
            new DateTime(2022, 4, 30),
            new DateTime(2022, 5, 30),
            new DateTime(2022, 6, 28),
            new DateTime(2022, 7, 28),
            new DateTime(2022, 8, 27),
            new DateTime(2022, 9, 25),
            new DateTime(2022, 10, 25),
            new DateTime(2022, 11, 23),
            new DateTime(2022, 12, 23),
            new DateTime(2023, 1, 21),
            new DateTime(2023, 2, 20),
            new DateTime(2023, 3, 21),
            new DateTime(2023, 4, 20),
            new DateTime(2023, 5, 19),
            new DateTime(2023, 6, 18),
            new DateTime(2023, 7, 17),
            new DateTime(2023, 8, 16),
            new DateTime(2023, 9, 15),
            new DateTime(2023, 10, 14),
            new DateTime(2023, 11, 13),
            new DateTime(2023, 12, 12),
            new DateTime(2024, 1, 11),
            new DateTime(2024, 2, 9),
            new DateTime(2024, 3, 10),
            new DateTime(2024, 4, 8),
            new DateTime(2024, 5, 8),
            new DateTime(2024, 6, 6),
            new DateTime(2024, 7, 5),
            new DateTime(2024, 8, 4),
            new DateTime(2024, 9, 3),
            new DateTime(2024, 10, 2),
            new DateTime(2024, 11, 1),
            new DateTime(2024, 12, 1),
            new DateTime(2024, 12, 30),
            new DateTime(2025, 1, 29),
            new DateTime(2025, 2, 28),
            new DateTime(2025, 3, 29),
            new DateTime(2025, 4, 27),
            new DateTime(2025, 5, 27),
            new DateTime(2025, 6, 25),
            new DateTime(2025, 7, 24),
            new DateTime(2025, 8, 23),
            new DateTime(2025, 9, 21),
            new DateTime(2025, 10, 21),
            new DateTime(2025, 11, 20),
            new DateTime(2025, 12, 20),
            new DateTime(2026, 1, 18),
            new DateTime(2026, 2, 17),
            new DateTime(2026, 3, 19),
            new DateTime(2026, 4, 17),
            new DateTime(2026, 5, 16),
            new DateTime(2026, 6, 15),
            new DateTime(2026, 7, 14),
            new DateTime(2026, 8, 12),
            new DateTime(2026, 9, 11),
            new DateTime(2026, 10, 10),
            new DateTime(2026, 11, 9),
            new DateTime(2026, 12, 9),
            new DateTime(2027, 1, 7),
            new DateTime(2027, 2, 6),
            new DateTime(2027, 3, 8),
            new DateTime(2027, 4, 7),
            new DateTime(2027, 5, 6),
            new DateTime(2027, 6, 4),
            new DateTime(2027, 7, 4),
            new DateTime(2027, 8, 2),
            new DateTime(2027, 9, 30),
            new DateTime(2027, 10, 29),
            new DateTime(2027, 11, 28),
            new DateTime(2027, 12, 27),
            new DateTime(2028, 1, 26),
            new DateTime(2028, 2, 25),
            new DateTime(2028, 3, 26),
            new DateTime(2028, 4, 24),
            new DateTime(2028, 5, 24),
            new DateTime(2028, 6, 22),
            new DateTime(2028, 7, 22),
            new DateTime(2028, 8, 20),
            new DateTime(2028, 9, 18),
            new DateTime(2028, 10, 18),
            new DateTime(2028, 11, 16),
            new DateTime(2028, 12, 16),
            new DateTime(2029, 1, 14),
            new DateTime(2029, 2, 13),
            new DateTime(2029, 3, 15),
            new DateTime(2029, 4, 13),
            new DateTime(2029, 5, 13),
            new DateTime(2029, 6, 12),
            new DateTime(2029, 7, 11),
            new DateTime(2029, 8, 10),
            new DateTime(2029, 9, 8),
            new DateTime(2029, 10, 7),
            new DateTime(2029, 11, 6),
            new DateTime(2029, 12, 5),
            new DateTime(2030, 1, 4),
            new DateTime(2030, 2, 2),
            new DateTime(2030, 3, 4),
            new DateTime(2030, 4, 2),
            new DateTime(2030, 5, 2),
            new DateTime(2030, 6, 1),
            new DateTime(2030, 6, 30),
            new DateTime(2030, 7, 30),
            new DateTime(2030, 8, 29),
            new DateTime(2030, 9, 27),
            new DateTime(2030, 10, 26),
            new DateTime(2030, 11, 25),
            new DateTime(2030, 12, 24),
            new DateTime(2031, 1, 23),
            new DateTime(2031, 2, 21),
            new DateTime(2031, 3, 23),
            new DateTime(2031, 4, 21),
            new DateTime(2031, 5, 21),
            new DateTime(2031, 6, 19),
            new DateTime(2031, 7, 19),
            new DateTime(2031, 8, 18),
            new DateTime(2031, 9, 16),
            new DateTime(2031, 10, 16),
            new DateTime(2031, 11, 14),
            new DateTime(2032, 12, 14),
            new DateTime(2032, 1, 12),
            new DateTime(2032, 2, 11),
            new DateTime(2032, 3, 11),
            new DateTime(2032, 4, 10),
            new DateTime(2032, 5, 9),
            new DateTime(2032, 6, 8),
            new DateTime(2032, 7, 7),
            new DateTime(2032, 8, 6),
            new DateTime(2032, 9, 4),
            new DateTime(2032, 10, 4),
            new DateTime(2032, 11, 3),
            new DateTime(2032, 12, 2),
            new DateTime(2033, 1, 1),
            new DateTime(2033, 1, 30),
            new DateTime(2033, 3, 1),
            new DateTime(2033, 3, 30),
            new DateTime(2033, 4, 29),
            new DateTime(2033, 5, 28),
            new DateTime(2033, 6, 26),
            new DateTime(2033, 7, 26),
            new DateTime(2033, 8, 24),
            new DateTime(2033, 9, 23),
            new DateTime(2033, 10, 23),
            new DateTime(2033, 11, 22),
            new DateTime(2033, 12, 21),
            new DateTime(2034, 1, 20),
            new DateTime(2034, 2, 18),
            new DateTime(2034, 3, 20),
            new DateTime(2034, 4, 18),
            new DateTime(2034, 5, 18),
            new DateTime(2034, 6, 16),
            new DateTime(2034, 7, 15),
            new DateTime(2034, 8, 14),
            new DateTime(2034, 9, 12),
            new DateTime(2034, 10, 12),
            new DateTime(2034, 11, 11),
            new DateTime(2034, 12, 10),
            new DateTime(2035, 1, 9),
            new DateTime(2035, 2, 8),
            new DateTime(2035, 3, 9),
            new DateTime(2035, 4, 8),
            new DateTime(2035, 5, 7),
            new DateTime(2035, 6, 6),
            new DateTime(2035, 7, 5),
            new DateTime(2035, 8, 3),
            new DateTime(2035, 9, 2),
            new DateTime(2035, 10, 1),
            new DateTime(2035, 10, 31),
            new DateTime(2035, 11, 29),
            new DateTime(2035, 12, 29)
        };

        /// <summary>
        /// Returns a list of new moon dates in the date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="thru"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public static IEnumerable<DateTime> EachNewMoon(DateTime from, DateTime thru)
        {
            if (from.Year > thru.Year)
            {
                throw new ArgumentException("From date must be earlier than thru date");
            }

            int fromYear = _newMoons.First().Year;
            int thruYear = _newMoons.Last().Year;

            if (from.Year < fromYear || thru.Year > thruYear)
            {
                throw new NotImplementedException(string.Format("Only supported between {0} and {1}", fromYear, thruYear));
            }

            return _newMoons.Where(m => m.Year >= from.Year && m.Year <= thru.Year);
        }
    }
}
