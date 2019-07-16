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
        
        public int OpeningHymnID { get; set; }
        public Hymn OpeningHymn { get; set; }
        public int SacramentHymnID { get; set; }
        public Hymn SacramentHymn { get; set; }
        public int IntermediateHymnID { get; set; }
        public Hymn IntermediateHymn { get; set; }
        public int ClosingHymnID { get; set; }
        public Hymn ClosingHymn { get; set; }

        public int InvocationID { get; set; }
        public Member Invocation { get; set; }

        public int BenedictionID { get; set; }
        public Member Benediction { get; set; }

        //public ICollection<Member> Speakers { get; set; }


    }
}
