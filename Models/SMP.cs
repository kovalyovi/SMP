using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SMP
    {
        public int ID { get; set; }

        public int WardID { get; set; }
        public Ward Ward { get; set; }

        public int PresidingID { get; set; }
        public Member Presiding { get; set; }

        public int ConductingID { get; set; }
        public Member Conducting { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Hymn> Hymns { get; set; }
        public int InvocationID { get; set; }
        public Member Invocation { get; set; }

        public int BenedictionID { get; set; }
        public Member Benediction { get; set; }

        public ICollection<Member> Speakers { get; set; }


    }
}
