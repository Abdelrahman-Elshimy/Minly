using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class StarRateDTO
    {
        public int Id { get; set; }

        public double Rate { get; set; }

        public int StarId { get; set; }
        public OnlyStarDTO Star { get; set; }


        public string ApiUserId { get; set; }
        public UserDTO ApiUser { get; set; }
    }
    public class CreateStarRate
    {
        public double Rate { get; set; }

        public int StarId { get; set; }
        public string ApiUserId { get; set; }
    }
}
