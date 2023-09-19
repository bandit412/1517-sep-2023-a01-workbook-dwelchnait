using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ResidentAddress Address { get; set; }

        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public string FullName { get { return LastName + ", " + FirstName; } }

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";
          
        }
        public Person(string firstname, string lastname, ResidentAddress address, List<Employment> employlmentpositions)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employlmentpositions != null)
            {
                EmploymentPositions = employlmentpositions;
            }
        }

    }
}
