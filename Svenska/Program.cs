using Microsoft.VisualStudio.TestTools.UnitTesting;
using Svenska;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Svenska
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Vänligen skriv in något nedan:");
            string inmatning = Console.ReadLine();

            int svenska = 0;
            int å = 0;
            int ä = 0;
            int ö = 0;

            foreach (char c in inmatning)
            {
                if (c == 'å' | c == 'Å' | c == 'ä' | c == 'Ä' | c == 'ö' | c == 'Ö')
                {
                    svenska++;
                }
                if (c == 'å' | c == 'Å')
                {
                    å++; //Utökning Statistik, Antal förekomster av å/Å,ä/Ä,ö/Ö i texten.
                }
                if (c == 'ä' | c == 'Ä')
                {
                    ä++;
                }
                if (c == 'ö' | c == 'Ö')
                {
                    ö++;
                }
            }
            if (svenska > 0)
            {
                Console.WriteLine("Texten är på Svenska.");
            }
            else
            {
                Console.WriteLine("Texten är inte på Svenska.");
            }
            Console.WriteLine("Antal Svenska bokstäver " + svenska);
            Console.WriteLine("Antal å/Å i texten: " + å);
            Console.WriteLine("Antal ä/Ä i texten: " + ä);
            Console.WriteLine("Antal ö/Ö i texten: " + ö);

        }
    }
}
[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void Svenska()
    {
        using FakeConsole console = new FakeConsole("Förälskad");
        Program.Main();
        Assert.AreEqual("Texten är på Svenska.", console.Lines[0]);
        Assert.AreEqual("Antal Svenska bokstäver 2", console.Lines[1]);
    }
    [TestMethod]
    public void InteSvenska()
    {
        using FakeConsole console = new FakeConsole("hello");
        Program.Main();
        Assert.AreEqual("Texten är inte på Svenska.", console.Lines[0]);
        Assert.AreEqual("Antal Svenska bokstäver 0", console.Lines[1]);
    }
    [TestMethod]
    public void AntalSvenskaBokstäver()
    {
        using FakeConsole console = new FakeConsole("åÅäÄöÖ");
        Program.Main();
        Assert.AreEqual("Texten är på Svenska.", console.Lines[0]);
        Assert.AreEqual("Antal Svenska bokstäver 6", console.Lines[1]);
        Assert.AreEqual("Antal å/Å i texten: 2", console.Lines[2]);
        Assert.AreEqual("Antal ä/Ä i texten: 2", console.Lines[3]);
        Assert.AreEqual("Antal ö/Ö i texten: 2", console.Lines[4]);
    }
}
