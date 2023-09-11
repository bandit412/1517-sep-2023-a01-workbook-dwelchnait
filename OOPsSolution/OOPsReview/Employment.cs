using System;
using System.Collections.Generic;
using System.Linq;
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
        SupervisoryLevel _Level;
        #endregion

        #region Behaviours (aka methods)
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
                if (value < 0.0)
                {
                    throw new ArgumentException($"Employment years ({value}) cannot be a negative value");
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
        #endregion
    }
}
