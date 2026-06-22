using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricityMeter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Meters meterslist = new Meters();

            Console.WriteLine("--------------------------");
            Console.WriteLine("Evidence měřičů");
            Console.WriteLine("--------------------------");

            int volba = 0;
            while (volba != 5)
            {
                Console.WriteLine("\nVyberte akci:");
                Console.WriteLine("1 - Přidat nového měřiče");
                Console.WriteLine("2 - Vypsat všechny měřiče");
                Console.WriteLine("3 - Vyhledat měřiče");
                Console.WriteLine("4 - Odečíst aktuální stav měřiče");
                Console.WriteLine("5 - Konec");

                Console.Write("Vaše volba: ");
                if (!int.TryParse(Console.ReadLine(), out int akce))
                {
                    Console.WriteLine("Neplatná volba. Zadejte číslo 1-5.");
                    continue;
                }

                switch (akce)
                {
                    case 1:
                   
                        int meterId = ZiskeMeterId("Zadejte ID měřiče: ");
                        double voltage = ZiskeVoltage("Zadejte napětí měřiče: ");
                        string serialNumber = ZiskejText("Zadejte sériové číslo měřiče: ");
                        bool isConnected = bool.Parse(ZiskejText("Zadejte stav připojení měřiče (true/false): "));
                        string simCard = ZiskejText("Zadejte číslo SIM karty: ");

                        double reading = ZiskeVoltage("Zadejte počáteční stav elektroměru (kWh): ");

                        Meter novy = new Meter(meterId, voltage, serialNumber, isConnected, simCard, reading);
                        meterslist.PridejMeter(novy);

                        Console.WriteLine("\nMěřič byl úspěšně přidán:");
                        Console.WriteLine(novy);
                        break;

         
                    case 2:
                        Console.WriteLine("\nSeznam všech měřičů:");
                        foreach (var m in meterslist.VratVsechnyMetry())
                        {
                            Console.WriteLine(m);
                            Console.WriteLine("--------------------------");
                        }
                        break;

                    case 3:
                        int hledanemeterId = ZiskeMeterId("Zadejte ID měřiče: ");
                        string hledaneserialNumber = ZiskejText("Zadejte sériové číslo měřiče: ");

                        var nalezeni = meterslist.NajdiMetry(hledanemeterId, hledaneserialNumber);

                        if (nalezeni.Count > 0)
                        {
                            Console.WriteLine("\nNalezení pojištěnci:");
                            foreach (var p in nalezeni)
                            {
                                Console.WriteLine(p);
                                Console.WriteLine("--------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Měřič nebyl nalezen.");
                        }
                        break;
                    case 4:

                        int id = ZiskeMeterId("Zadejte ID měřiče: ");

                        double? stav = meterslist.ReadMeter(id);

                        if (stav != null)
                        {
                            Console.WriteLine($"Aktuální odečet je {stav} kWh");
                        }
                        else
                        {
                            Console.WriteLine("Měřič není připojen nebo neexistuje.");
                        }

                        break;

                    case 5:
                        Console.WriteLine("Ukončuji program...");
                        return;

                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }
            }
        }
        /// <summary>
        /// Získá textový vstup a ověří, že není prázdný a neobsahuje číslice.
        /// </summary>
        

        static int ZiskeMeterId(string vyzva)
        {
            while (true)
            {
                Console.Write(vyzva);
                if (int.TryParse(Console.ReadLine(), out int meterId) && meterId > 0)
                    return meterId;
                Console.WriteLine("Neplatné ID měřiče. Zadejte kladné číslo.");
            }
        }




        /// <summary>
        /// Získá číselný vstup pro věk a ověří, že je v rozumném rozmezí.
        /// </summary>
        static double ZiskeVoltage(string vyzva)
        {
            while (true)
            {
                Console.Write(vyzva);
                if (double.TryParse(Console.ReadLine(), out double voltage) && voltage > 0)
                    return voltage;
                Console.WriteLine("Neplatné napětí. Zadejte kladné číslo.");
            }
        }
        static string ZiskejText(string vyzva)
        {
            while (true)
            {
                Console.Write(vyzva);
                string vstup = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(vstup))
                    return vstup;

                Console.WriteLine("Vstup nesmí být prázdný.");
            }
        }

    }
}