using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Ward
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public int BishopID { get; set; }
        public Member Bishop { get; set; }

        [DisplayName("First Counselor")]
        public int FirstID { get; set; }
        [DisplayName("First Counselor")]
        public Member First { get; set; }
        [DisplayName("Second Counselor")]
        public int SecondID { get; set; }
        [DisplayName("Second Counselor")]
        public Member Second { get; set; }
    }
}
