using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Member
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public String FirstName { get; set; }
        [DisplayName("Last Name")]
        public String LastName { get; set; }

    }
}
