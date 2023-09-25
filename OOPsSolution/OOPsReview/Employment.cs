using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        #region Data Members

        //hold a piece of data
        //data is valuable
        //securing access by making them private
        //access and modification will be done via
        // other components of the class

        private string _Title;
        private double _Years;
        private SupervisoryLevel _Level;
        #endregion

        #region Behaviours (aka methods)
        //Behaviours (aka methods)

        //method syntax:  accesslevel [override][static] rdt methodname ([list of parameters])
        //                  { ...... }

        public void SetEmploymentResponsibilityLevel( SupervisoryLevel level )
        {
            //the property has a private set
            //therefore the only ways to assign a value to the property
            //  is via a) constructor, b) another property, or c) a method

            //what about validation?
            //validation can be done in multiple places
            //  a) can it be done in this method?   Yes
            //  b) can it be done within the property? Yes if the property if fully-implemented
            Level = level;
        }

        public void CorrectStartDate(DateTime startdate)
        {
            //Property StartDate is auto-implementd
            //Property StartDate has NO validation
            //If you need to do any validation on the incoming value
            //  you will need to do the validation in the method
            //in this example we will ensure that the startdate is not a day in the future
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate = startdate;
        }

        public double UpdateCurrentEmploymentYearsExperience()
        {
            TimeSpan span = DateTime.Now - StartDate;
            Years = Math.Round((span.Days / 365.25), 1);
            return Years;
        }

        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";
        }
        #endregion

        #region Properties
        //a property is associated with a single piece of data

        //there are two basic forms for properties: auto implemented and fully implemented

        //fully implemented property
        //why?
        // it allows for additional logic to be included in the
        //      execution of the property
        // a typical use will be to include validation

        public string Title
        {
            //retrieves the data to return
            get { return _Title; }
            //ensure that the title have value (not empty)
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is missing a description");
                }
                _Title = value;
            }
        }
        public double Years
        {
            //retrieves the data to return
            get { return _Years; }
            //ensure that the title have value (not empty)
            set
            {
                //if (value < 0.0)

                //use the Utilities class method to check the data value
                if(!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException($"Employment years ({value}) cannot be a negative value");
                }
                _Years = value;
            }
        }
        public SupervisoryLevel Level
        {
            get { return _Level; }
            private set
            {
                // a private set means that the property
                //      can only be set via code within
                //      a constructor or a another method/property
                //      within the class
                // this property mutator cannot be accessed directly
                //      by logic outside of this class
                // an advantage of doing this is increasing security
                //      on the field as any change is under the
                //      control of the class
                //
                // you can validate that an acceptable integer value
                //      was passed into this property
                // syntax:  Enum.IsDefined(typeof(xxxx), value)
                //              where xxx is the enum name
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"SupervisoryLevel is invalid {value}");
                }
                _Level = value;
            }
        }
        // this property is an example of an auto-implemented property
        // there is no validation within the property
        // there is NO private data member for this property
        //  the system will generate an internal storage area for the data
        //      and handle the setting and getting from that storage
        // auto-implemented properties can have either a public or private set
        // using a public or private set is a design decision
        public DateTime StartDate { get; private set; }

        #endregion

        #region Constructors
        //Constructors

        //the purpose of a constructor is to create an instance of your
        //  class in a known state

        //does a class need a constructor? NO
        //  if a class does NOT have a constructor then the system will
        //      create the instance and assign the system default value to data
        //      member and/or auto implemented property
        //  if you have no constructor the common phrase is "using a system constructor"

        //IF YOU CODE A CONSTRUCTOR IN YOUR CLASS YOU ARE RESPONSIBLE FOR ANY AND ALL
        //  CONSTRUCTOR FOR THE CLASS!!!

        // default constructor
        //you can apply your own literal values for your data memebers and/or auto-implemented
        //  properties that differ from the system default values
        //why?
        //  you may have data that is validated and using the system default values that would
        //  cause an exception

        //constructors DO NOT have a return datatype in their header definition
        //constructors CANNOT be called directly by an developer logic
        //constructors are referenced (called) indirectly by using the "new" command
        public Employment()
        {
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
        }

        //greedy constructor

        //a greedy constructor is one that accepts a parameter list of values
        //  to assign to your instance data on creation of the instance
        //generally your greedy constructor constaints a parameter on the signature
        //  for each data member/auto-implemented property in your class definition

        //if you have any default values for your parameters, the default parameters
        //  must appear AFTER the non-default parameters in the parameter list
        //in this example we will default Years to 0
        public Employment(string title, SupervisoryLevel level, DateTime startdate,
                            double years = 0.0)
        {
            Title=title;
            Level = level;
            //Years = years;

            //you can add logic to your constructor to ensure that the incoming value
            //  is valid
            //this is useful for auto-implemented properties
            //this is useful for private sets which do not contain validation code
            
            //in this example we will ensure that the startdate is not a day in the future
            if(startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate = startdate;

            // one can add additional logic to adjust your starting values
            // ensure that years is appropriate for the entered startdate
            if (years > 0.0)
            {
                Years = years;
            }
            else
            {
                TimeSpan span =  DateTime.Now - StartDate;
                Years = Math.Round((span.Days / 365.25), 1);
            }
        }
        #endregion
    
    
        //Parsing(string)

        //attempts to change the contents of a string to another datatype
        //this method contains basic validation on the number of fields
        //  if there are insufficient values then expected an error can be thrown
        //example
        //    string 55 --> int x = int.Parse(string); <-- success
        //           bob --> int x = int.Parse(string); <-- abort with a message

        //if this can be done on an int class why not on our Employment class?
        //we will need to add a method (Parse) that receives a string
        //  the string will need to have sufficient values to create a proper Employment

        public static Employment Parse(string item)
        {
            //test is a string of csv values (comma separated values)
            //   note you could use some other delimator
            //separate the string of values into individual string values
            //      create an array of strings resulting fromusing .Split(delimator)
            string[] pieces = item.Split(',');

            //verify that sufficient and correct number of values exist to
            //  create the Employment instance
            if(pieces.Length != 4 )
            {
                throw new FormatException($"String not in expected format. Missing/excessive value(s) {item}");
            }

            //return an instance of Employment
            // the instance will be created by the separate pieces
            // the pieces will be converted if required using the appropriate parsing

            return new Employment(pieces[0],
                                    (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel),pieces[1]),
                                    DateTime.Parse(pieces[2]),
                                    double.Parse(pieces[3]));         

        }

        //the TryParse method will receive a string AND output an instance of
        //  Employment as an output parameter AND return a boolean success value

        //syntax:   .TryParse    xxxx.TryParse(string, out datatype parametername)
        //example   int.TryParse   int.TryParse(inputValue, out int myIntegerNumber)

        //the method will return a boolean value indicate success
        //to avoid duplicate code; this method will call .Parse()

        public static bool TryParse(string item, out Employment result)
        {
            result = null;
            //you do not have to capture the error message if throw from Parse

            return true;
        }
        
     }
}
