using System;
using System.Collections.Generic;
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

        public int FirstID { get; set; }
        public Member First { get; set; }

        public int SecondID { get; set; }
        public Member Second { get; set; }
    }
}
