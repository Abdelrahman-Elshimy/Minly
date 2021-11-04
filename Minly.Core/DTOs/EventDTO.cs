using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Description { get; set; }
        public string Description_ar { get; set; }

        public string Image { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<EventMembershipWithoutInsideDataDTO> EventMemberships { get; set; }

        public int EventTypeId { get; set; }
        public EventTypeBasicDTO EventType { get; set; }

        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ICollection<EventVideo> EventVideos { get; set; }
        public virtual ICollection<EventRateDTO> EventRates { get; set; }
    }
}
