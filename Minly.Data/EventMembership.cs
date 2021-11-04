using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class EventMembership
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Name_ar { get; set; }

        public string Description { get; set; }
        public string Description_ar { get; set; }

        public double Price { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
