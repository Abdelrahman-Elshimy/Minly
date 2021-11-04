using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class RequestStarDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }


        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

        public int StarId { get; set; }
        public Star Star { get; set; }
    }

    public class CreateRequestStarDTO
    {
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public string ApiUserId { get; set; }
        public int StarId { get; set; }
    }
}
