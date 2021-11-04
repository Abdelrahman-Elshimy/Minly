using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class EventVideo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Description { get; set; }
        public string Description_ar { get; set; }
        public string Link { get; set; }

        [ForeignKey(nameof(EventMembership))]
        public int EventMembershipId { get; set; }
        public EventMembership EventMembership { get; set; }
    }
}
