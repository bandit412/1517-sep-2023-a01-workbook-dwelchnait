﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public record ResidentAddress(int Number, string Street, string City,
                            string Province, string PostalCode)
    {
        //this new datatype behaves very much like a class
        //the fields are listed on the declaration
        //this is a read only version of a class
        //when declaring an instance you must pass in the data to be held
        //you cannot alter the record instance
        //if you need to alter the data within the instance you must
        //      create a new instance and pass the data to the new instance

        //OPTIONALLY
        //you can add your own greedy constructor
        //you can add methods to this datatype

        public override string ToString()
        {
            return $"{Number},{Street},{City},{Province},{PostalCode}";
        }
    }
}
