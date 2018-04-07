/*
 * C9519
 * Program4
 * 29 November 2016
 * CIS 200-01
 * ParcelAscTypeDescCost sorts parcels first ascending by type then
 * descending by cost.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ParcelAscTypeDescCost : Comparer<Parcel>
{
    // Precondition:  None
    // Postcondition: Orders Parcels ascending by type then descending by zip
    //                For Type
    //                When p1's type < p2's type, method returns negative #
    //                When p1's type == p2's type, method returns zero
    //                When p1's type > p2's type, method returns positive #
    //                For Cost
    //                When p1's cost < p2's cost, method returns positive #
    //                When p1's cost == p2's cost, method returns zero
    //                When p1's cost > p2's cost, method returns negative #
    public override int Compare(Parcel p1, Parcel p2)
    {
        if (p1 == null && p2 == null)
            return 0;

        if (p1 == null)
            return -1;

        if (p2 == null)
            return 1;

        if (p1.GetType().ToString().CompareTo(p2.GetType().ToString()) != 0)
            return p1.GetType().ToString().CompareTo(p2.GetType().ToString());
        else
            return (-1) * p1.CalcCost().CompareTo(p2.CalcCost());
    }
}
