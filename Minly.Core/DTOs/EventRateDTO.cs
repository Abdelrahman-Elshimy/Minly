using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class EventRateDTO
    {
        public int Id { get; set; }

        public double Rate { get; set; }

        public int EventId { get; set; }
        public EventDTO Event { get; set; }


        public string ApiUserId { get; set; }
        public UserDTO ApiUser { get; set; }
    }
    public class CreateEventRate
    {
        public double Rate { get; set; }

        public int EventId { get; set; }
        public string ApiUserId { get; set; }
    }
}
