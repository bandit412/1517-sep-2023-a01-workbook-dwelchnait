using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public enum SupervisoryLevel
    {
        ///<summary>
        ///enum names are strings representing an integer value
        ///by default the integer values starts at 0 and increments by 1
        ///one could assign their own values to each of the enum names
        /// </summary>
        Entry,              //0
        TeamMember,         //1
        TeamLeader,         //2
        Supervisor,         //3
        DepartmentHead,     //4
        Owner               //5
    }
}
