using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class StarService
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int StarId { get; set; }
        public int ServiceId { get; set; }
        public Star Star { get; set; }
        public Service Service { get; set; }
    }
}
