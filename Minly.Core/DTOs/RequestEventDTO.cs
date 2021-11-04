using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class RequestEventDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }


        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }

    public class CreateRequestEventDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public string ApiUserId { get; set; }
        public int EventId { get; set; }
    }
}
