/*
 * C9519
 * Program4
 * 29 November 2016
 * CIS 200-01
 * ParcelDescOrderByDestZip sorts parcels descending by
 * destination zip Code
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ParcelDescOrderByDestZip : Comparer<Parcel>
{
    // Precondition:  None
    // Postcondition: Orders Parcels to descending by zip
    //                When p1 < p2, method returns positive #
    //                When p1 == p2, method returns zero
    //                When p1 > p2, method returns negative #
    public override int Compare(Parcel p1, Parcel p2)
    {
        if (p1 == null && p2 == null)
            return 0;

        if (p1 == null)
            return -1;

        if (p2 == null)
            return 1;

        return (-1) * p1.DestinationAddress.Zip.CompareTo(p2.DestinationAddress.Zip);
    }
}
