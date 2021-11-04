using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class Event
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

        public virtual ICollection<EventMembership> EventMemberships { get; set; }

        [ForeignKey(nameof(EventType))]
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }

        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ICollection<EventVideo> EventVideos { get; set; }
        public virtual ICollection<EventRate> EventRates { get; set; }

    }
}
