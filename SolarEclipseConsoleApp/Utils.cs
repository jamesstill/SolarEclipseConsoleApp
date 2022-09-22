using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarEclipseConsoleApp
{
    internal static class Utils
    {
        /// <summary>
        /// Meeus (49.1)
        /// Time of mean conjuction or opposition
        /// </summary>
        /// <param name="k"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static double ToJDE(int k, double T)
        {
            return 2451550.09766 +
                (29.530588861 * k) +
                (0.00015437 * (T * T)) -
                (0.000000150 * (T * T * T)) +
                (0.00000000073 * (T * T * T * T));
        }

        /// <summary>
        /// Meeus (49.2)
        /// Baseline value k where k = 0 is 6 Jan 2000 (first new moon of J2000.0 epoch).
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int ToK(this DateTime d)
        {
            double decimalYear = (d.ToDecimalYear() - 2000) * 12.3685;
            return (int)Math.Floor(decimalYear);
        }

        /// <summary>
        /// Meeus (49.3)
        /// Time T is the time in Julian centures since the J2000.0 epoch
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double ToT(this int k)
        {
            return k / 1236.85;
        }

        /// <summary>
        /// Meeus (47.6)
        /// Earth's eccentricity in orbit
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public static double ToE(this double T)
        {
            return 1 - 0.002516 * T - 0.0000074 * T * T;
        }

        /// <summary>
        /// Meeus (49.4)
        /// Sun's mean anomaly at time JDE
        /// </summary>
        /// <param name="k"></param>
        /// <param name="T"></param>
        /// <returns>M</returns>
        public static double ToM(int k, double T)
        {
            var i = 2.5534 +
                (29.10535670 * k) -
                (0.0000014 * (T * T)) -
                (0.00000011 * (T * T * T));

            return i.ToReducedAngle().ToRadians();
        }

        /// <summary>
        /// Meeus (49.5)
        /// Moon's mean anomaly at time JDE
        /// </summary>
        /// <param name="k"></param>
        /// <param name="T"></param>
        /// <returns>M′</returns>
        public static double ToMPrime(int k, double T)
        {
            var i = 201.5643 +
                (385.81693528 * k) +
                (0.0107582 * (T * T)) +
                (0.00001238 * (T * T * T)) -
                (0.000000058 * (T * T * T * T));

            return i.ToReducedAngle().ToRadians();
        }

        /// <summary>
        /// Meeus (49.6)
        /// Moon's argument of latitude
        /// </summary>
        /// <param name="k"></param>
        /// <param name="T"></param>
        /// <returns>F</returns>
        public static double ToF(int k, double T)
        {
            var i = 160.7108 +
                (390.67050284 * k) -
                (0.0016118 * (T * T)) -
                (0.00000227 * (T * T * T)) +
                (0.000000011 * (T * T * T * T));

            return i.ToReducedAngle();
        }

        /// <summary>
        /// Meeus (49.7)
        /// Longitude of the ascending node of the lunar orbit
        /// </summary>
        /// <param name="k"></param>
        /// <param name="T"></param>
        /// <returns>Ω</returns>
        public static double ToO(int k, double T)
        {
            var i = 124.7746 -
                (1.56375588 * k) +
                (0.0020672 * (T * T)) +
                (0.00000215 * (T * T * T));

            return i.ToReducedAngle().ToRadians();
        }

        /// <summary>
        /// Angle F prime to obtain time of maximum eclipse
        /// </summary>
        /// <param name="F"></param>
        /// <param name="O"></param>
        /// <returns></returns>
        public static double ToFPrime(double F, double O)
        {
            var i = F - (0.02665 * Math.Sin(O));
            return i.ToReducedAngle().ToRadians();
        }

        /// <summary>
        /// Angle A prime to obtain time of maximum eclipse
        /// </summary>
        /// <param name="k"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static double ToAPrime(double k, double T)
        {
            var i = 299.77 + (0.107408 * k) - (0.009173 * (T * T));
            return i.ToReducedAngle().ToRadians();
        }

        public static double ToP(double E, double Sm, double Mm, double Fp)
        {
            return
                (0.2070 * E * Math.Sin(Sm)) +
                (0.0024 * E * Math.Sin(Sm * 2)) -
                (0.0392 * Math.Sin(Mm)) +
                (0.0116 * Math.Sin(Mm * 2)) -
                (0.0073 * E * Math.Sin(Mm + Sm)) +
                (0.0067 * E * Math.Sin(Mm - Sm)) +
                (0.0118 * Math.Sin(Fp * 2));
        }

        public static double ToQ(double E, double Sm, double Mm)
        {
            return
                5.2207 -
                (0.0048 * E * Math.Cos(Sm)) +
                (0.0020 * E * Math.Cos(Sm * 2)) -
                (0.3299 * Math.Cos(Mm)) -
                (0.0060 * E * Math.Cos(Mm + Sm)) +
                (0.0041 * E * Math.Cos(Mm - Sm));
        }

        public static double ToW(double Fp)
        {
            return Math.Abs(Math.Cos(Fp));
        }

        /// <summary>
        /// Least distance from the axis of the Moon's shadow to the center of 
        /// the Earth in units of the equitorial radius of the Earth (6378 km)
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Q"></param>
        /// <param name="Fp"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        public static double ToG(double P, double Q, double Fp, double W)
        {
            return (P * Math.Cos(Fp) + Q * Math.Sin(Fp)) * (1 - 0.0048 * W);
        }

        /// <summary>
        /// Moon's umbral cone in the fundamental plane
        /// </summary>
        /// <param name="E"></param>
        /// <param name="Sm"></param>
        /// <param name="Mm"></param>
        /// <returns></returns>
        public static double ToU(double E, double Sm, double Mm)
        {
            return
                0.0059 +
                0.0046 * E * Math.Cos(Sm) -
                0.0182 * Math.Cos(Mm) +
                0.0004 * Math.Cos(Mm * 2) -
                0.0005 * Math.Cos(Sm + Mm);
        }

        /// <summary>
        /// Meeus (54.2)
        /// For a partial eclipse the magnitude at its greatest point
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double ToGreatestMagnitude(double u, double g)
        {
            return (1.5433 + u - Math.Abs(g)) / (0.5461 + 2 * u);
        }

        /// <summary>
        /// Returns the time of greatest eclipse in UTC
        /// </summary>
        /// <param name="jde"></param>
        /// <param name="E"></param>
        /// <param name="Mm"></param>
        /// <param name="Sm"></param>
        /// <param name="Fp"></param>
        /// <param name="Ap"></param>
        /// <param name="O"></param>
        /// <returns></returns>
        public static DateTime TimeOfGreatestEclipse(this double jde, double E, double Mm, double Sm, double Fp, double Ap, double O)
        {
            var jdeCorrection =
                (-0.4075 * Math.Sin(Mm)) +
                (0.1721 * E * Math.Sin(Sm)) +
                (0.0161 * Math.Sin(2 * Mm)) -
                (0.0097 * Math.Sin(2 * Fp)) +
                (0.0073 * E * Math.Sin(Mm - Sm)) -
                (0.0050 * E * Math.Sin(Mm + Sm)) -
                (0.0023 * Math.Sin(Mm - 2 * Fp)) +
                (0.0021 * E * Math.Sin(2 * Sm)) +
                (0.0012 * Math.Sin(Mm + 2 * Fp)) +
                (0.0006 * E * Math.Sin(2 * Mm + Sm)) -
                (0.0004 * Math.Sin(3 * Mm)) -
                (0.0003 * E * Math.Sin(Sm + 2 * Fp)) +
                (0.0003 * Math.Sin(Ap)) -
                (0.0002 * E * Math.Sin(Sm - 2 * Fp)) -
                (0.0002 * E * Math.Sin(2 * Mm - Sm)) -
                (0.0002 * Math.Sin(O));

            var correctedJDE = jde + jdeCorrection;
            var dt = ToDateTime(correctedJDE);

            // convert TD to UTC by subtracting ΔT
            var deltaT = ToDeltaT(dt.Year);
            return dt.AddSeconds(-deltaT);
        }


        /// <summary>
        /// Reduce very large angles to between 0 and 360 degrees
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double ToReducedAngle(this double d)
        {
            d = d % 360;
            if (d < 0)
            {
                d += 360;
            }

            return d;
        }

        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double ToRadians(this double d)
        {
            return (Math.PI / 180) * d;
        }

        /// <summary>
        /// NASA algorithm for approximate value of ΔT for a given year up to the year 2050
        /// See: https://eclipse.gsfc.nasa.gov/SEhelp/deltatpoly2004.html
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static double ToDeltaT(int year)
        {
            var t = year - 2000;
            return 62.92 + 0.32217 * t + 0.005589 * t * t;
        }

        /// <summary>
        /// Converts calendar date to decimal date. For example, the total solar 
        /// eclipse of 21 May 1993 (141st day of year) would be decimal 1993.38.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static double ToDecimalYear(this DateTime dt)
        {
            double daysInYear = (DateTime.IsLeapYear(dt.Year)) ? 366 : 365.2425;
            var fraction = dt.DayOfYear / daysInYear;
            return dt.Year + fraction;
        }

        /// <summary>
        /// Creates a date from a known Julian Day (JD) value.
        /// </summary>
        /// <param name="julianDay"></param>
        public static DateTime ToDateTime(double julianDay)
        {
            if (double.IsNaN(julianDay))
            {
                throw new ArgumentException("julianDay must be a valid value.");
            }

            double A;
            double B;
            int C;
            double D;
            int E;
            double jd = julianDay + 0.5;
            double Z = Math.Truncate(jd);
            double F = jd - Math.Truncate(jd);

            if (Z < 2299161)
            {
                A = Z;
            }
            else
            {
                var a = (int)((Z - 1867216.25) / 36524.25);
                A = Z + 1 + a - (int)(a / 4);
            }

            B = A + 1524;
            C = (int)((B - 122.1) / 365.25);
            D = (int)(365.25 * C);
            E = (int)((B - D) / 30.6001);
            double day = B - D - (int)(30.6001 * E) + F;

            var M = E switch
            {
                14 or 15 => E - 13,
                _ => E - 1,
            };
            var Y = M switch
            {
                1 or 2 => C - 4715,
                _ => C - 4715,
            };

            // leverage the C# TimeSpan struct
            var ts = TimeSpan.FromDays(day);

            return new(Y, M, ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
    }
}
