/*
 * C9519
 * Program4
 * 29 November 2016
 * CIS 200-01
 * Tests the ParcelDescOrderByDestZip and ParcelAscTypeDescCost classes as well as
 * the natural sort added to the Parcel class.
*/

// Program 1A
// CIS 200-01/76
// Fall 2016
// Due: 10/10/2016
// By: Andrew L. Wright (students use Grading ID)

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            Letter letter1 = new Letter(a1, a2, 3.95M);                             // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);         // Ground test object
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,     // Next Day test object
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            Letter letter2 = new Letter(a3, a2, 6.99M);                             // Letter test object
            GroundPackage gp2 = new GroundPackage(a4, a3, 11, 8, 3, 9.5);           // Ground test object
            NextDayAirPackage ndap2 = new NextDayAirPackage(a2, a3, 35, 25, 20,     // Next Day test object
                95, 9.50M);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a3, a1, 26.5, 19.5, 18.0, // Two Day test object
                40, TwoDayAirPackage.Delivery.Early);
            Letter letter3 = new Letter(a2, a3, 5.95M);                             // Letter test object
            GroundPackage gp3 = new GroundPackage(a3, a4, 5, 10, 2, 4);             // Ground test object
            NextDayAirPackage ndap3 = new NextDayAirPackage(a3, a1, 20, 14, 12,     // Next Day test object
                15, 5M);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a2, a1, 12, 8, 3.5,       // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(letter2);
            parcels.Add(gp2);
            parcels.Add(ndap2);
            parcels.Add(letter3);
            parcels.Add(gp3);
            parcels.Add(ndap3);
            parcels.Add(tdap3);
            parcels.Add(tdap3);

            // Lists parcel in original list
            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            // Lists parcel in order by cost
            parcels.Sort();
            Console.Out.WriteLine("Sorted list (natural order):");
            foreach (Parcel p in parcels)
                Console.WriteLine(p.CalcCost().ToString("C"));
            Pause();

            // Lists parcels in descending order by Destination Zip Code
            parcels.Sort(new ParcelDescOrderByDestZip());

            Console.Out.WriteLine("Sorted list (descending order) using Comparer:");
            foreach (Parcel p in parcels)
                Console.WriteLine(p.DestinationAddress.Zip.ToString("D5"));
            Pause();

            // Lists parcel in ascending order by Type and descending by cost
            parcels.Sort(new ParcelAscTypeDescCost());

            Console.Out.WriteLine("Sorted list (type ascending order then\r\ncost descending order) using Comparer:");
            foreach (Parcel p in parcels)
            {
                Console.Write($"{p.GetType(),-20} {p.CalcCost().ToString("C"), 10}");
                Console.WriteLine();
            }
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
