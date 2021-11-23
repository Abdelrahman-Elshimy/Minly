using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class StarResponse
    {
        [Key]
        public int Id { get; set; }

        public string Video { get; set; }
        public string Message { get; set; }
        public string Audio { get; set; }


        [ForeignKey(nameof(RequestStar))]
        public int RequestStarId { get; set; }
        public RequestStar RequestStar { get; set; }
    }
}
