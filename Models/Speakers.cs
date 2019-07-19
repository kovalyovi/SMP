using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Speakers
    {

        public int ID { get; set; }
        [DisplayName("Speaking")]
        public int SpeakerID { get; set; }
        public Member Speaker { get; set; }

        public string Topic { get; set; }
        [DisplayName("Sacrament Meeting Planner")]
        public int SMPID { get; set; }
        [DisplayName("Sacrament Meeting Planner")]
        public SMP SMP { get; set; }


    }
}
