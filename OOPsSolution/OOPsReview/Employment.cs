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
        #endregion

        #region Constructors
        #endregion
    }
}
