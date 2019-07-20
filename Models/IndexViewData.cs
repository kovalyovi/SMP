using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class IndexViewData
    {
        public IEnumerable<Hymn> Hymns { get; set; }
        public IEnumerable<Speakers> Speakers { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public Ward Ward { get; set; }
        public SMP SMP { get; set; }
    }
}
