using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SMP
    {
        public int ID { get; set; }

        [DisplayName("Ward")]
        public int WardID { get; set; }
        public Ward Ward { get; set; }

        [DisplayName("Presiding")]
        public int PresidingID { get; set; }
        public Member Presiding { get; set; }

        [DisplayName("Conducting")]
        public int ConductingID { get; set; }
        public Member Conducting { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("Opening Hymn")]
        public int OpeningHymnID { get; set; }
        public Hymn OpeningHymn { get; set; }
        [DisplayName("Sacrament Hymn")]
        public int SacramentHymnID { get; set; }
        public Hymn SacramentHymn { get; set; }
        [DisplayName("Intermediate Hymn")]
        public int IntermediateHymnID { get; set; }
        public Hymn IntermediateHymn { get; set; }
        [DisplayName("Closing Hymn")]
        public int ClosingHymnID { get; set; }
        public Hymn ClosingHymn { get; set; }

        [DisplayName("Invocation")]
        public int InvocationID { get; set; }
        public Member Invocation { get; set; }

        [DisplayName("Benediction")]
        public int BenedictionID { get; set; }
        public Member Benediction { get; set; }

        //public ICollection<Member> Speakers { get; set; }


    }
}
