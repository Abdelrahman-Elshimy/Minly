using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class EventMembershipBasic
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Name_ar { get; set; }

        public string Description { get; set; }
        public string Description_ar { get; set; }

        public double Price { get; set; }
    }
    public class EventMembershipDTO: EventMembershipBasic
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
    }

    public class EventMembershipWithoutInsideDataDTO: EventMembershipBasic
    {

    }
}
