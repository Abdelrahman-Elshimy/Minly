using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class StarRate
    {
        public int Id { get; set; }

        public double Rate { get; set; }

        [ForeignKey(nameof(Star))]
        public int StarId { get; set; }
        public Star Star { get; set; }


        [ForeignKey(nameof(ApiUser))]
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

    }
}
