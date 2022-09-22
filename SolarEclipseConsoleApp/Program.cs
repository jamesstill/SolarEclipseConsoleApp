using SolarEclipseConsoleApp;

// NASA's published canon: https://eclipse.gsfc.nasa.gov/5MCSE/5MCSE-Maps-10.pdf
Console.Write("Looking for solar eclipse candidates in the date range...");
Console.WriteLine(Environment.NewLine);

// examine all new moons in date range
DateTime startDate = new(2022, 1, 1);
DateTime endDate = new(2035, 12, 31);

foreach (var dt in NewMoonData.EachNewMoon(startDate, endDate))
{
    int k = Utils.ToK(dt);              // (49.2)
    var T = Utils.ToT(k);               // (49.3)  
    var JDE = Utils.ToJDE(k, T);        // (49.1)
    var E = Utils.ToE(T);               // (47.6)
    var Sm = Utils.ToM(k, T);           // (49.4)
    var Mm = Utils.ToMPrime(k, T);      // (49.5)
    var F = Utils.ToF(k, T);            // (49.6)
    var O = Utils.ToO(k, T);            // (49.7)
    var Fp = Utils.ToFPrime(F, O);      // (54.1)
    var Ap = Utils.ToAPrime(k, T);      // (54.1)
    var P = Utils.ToP(E, Sm, Mm, Fp);   // p. 381
    var Q = Utils.ToQ(E, Sm, Mm);       // p. 381
    var W = Utils.ToW(Fp);              // p. 381
    var g = Utils.ToG(P, Q, Fp, W);     // p. 381
    var u = Utils.ToU(E, Sm, Mm);       // p. 381

    // per Meeus: in the case of a central eclipse, the type of the eclipse can be determined by 
    // the following rules: if u < 0 then it's a total eclipse; if u > 0.0047 then it is annular;
    // if u is >= 0 and <= 0.0047 then it is either annular or annular-total ("hybrid"). 

    double absG = Math.Abs(g);
    double mag = 0.0;

    if (absG <= 1.5433 + u) // then some type of eclipse is visible from the Earth's surface
    {
        string eclipseType = "Unknown";
        if (absG >= 0.9972 && absG <= 1.5433 + u)
        {
            // the eclipse is not central but partial
            eclipseType = "Partial";

            // In a partial solar eclipse the magnitude of the eclipse is "the point of the surface 
            // of the Earth which comes closest to the axis of shadow" (Meeus, p. 382).
            mag = Utils.ToGreatestMagnitude(u, g); // (54.2)
        }
        else
        {
            // the eclipse is central
            if (u < 0)
            {
                eclipseType = "Total";
            }
            else if (u > 0.0047)
            {
                eclipseType = "Annular";
            }
            else // between 0 and 0.0047 so either annular or hybrid
            {
                var w = 0.00464 * Math.Sqrt(1 - g * g); // p. 382 (not numbered)
                eclipseType = (u < w) ? "Hybrid" : "Annular";
            }
        }

        //  the instant when the axis of the Moon's shadow cone passes closest to Earth's center
        var timeOfGreatestEclipseUTC = JDE.TimeOfGreatestEclipse(E, Mm, Sm, Fp, Ap, O);
        var timeDisplay = timeOfGreatestEclipseUTC.ToString("HH:mm");

        string dateDisplay = string.Format("{0,10}", dt.ToShortDateString());
        string eclipseTypeDisplay = string.Format("{0, 8}", eclipseType);

        string magDisplay = "";
        if (eclipseType == "Partial")
        {
            magDisplay = mag.ToString("0.0000");
        }

        string gDisplay = g.ToString("0.0000");

        Console.WriteLine("{0}: {1}  {2} UTC  mag: {3}  g: {4}",
            dateDisplay,
            eclipseTypeDisplay,
            timeDisplay,
            string.Format("{0, 6}", magDisplay),
            string.Format("{0, 6}", gDisplay));
    }
}

Console.WriteLine(Environment.NewLine);
Console.Write("Press ENTER to quit.");
Console.ReadKey();