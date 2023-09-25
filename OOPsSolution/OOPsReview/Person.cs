using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        public string FirstName 
        {
            get { return _FirstName; } 
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name must be supplied,");
                }
                _FirstName = value;
            }
        }
        public string LastName { get; set; }

        public ResidentAddress Address { get; set; }

        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public string FullName { get { return LastName + ", " + FirstName; } }

        public int NumberOfEmployments { get { return EmploymentPositions.Count; } }

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";
          
        }
        public Person(string firstname, string lastname, ResidentAddress address, List<Employment> employlmentpositions)
        {
           
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("Last name is required.");
            }
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employlmentpositions != null)
            {
                EmploymentPositions = employlmentpositions;
            }
        }

        public void ChangeName(string firstname, string lastname)
        {
           
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("Last name is required.");
            }
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddEmployment(Employment employment) 
        { 
            EmploymentPositions.Add(employment);
        }
    }
}
