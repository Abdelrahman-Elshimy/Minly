using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class RequestStar
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public bool Payed { get; set; }

        [ForeignKey(nameof(ApiUser))]
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

        [ForeignKey(nameof(Star))]
        public int StarId { get; set; }
        public Star Star { get; set; }
    }
}
