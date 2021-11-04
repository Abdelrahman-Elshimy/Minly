using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class StarCategory
    {
        public int Id { get; set; }
        public int StarId { get; set; }
        public int CategoryId { get; set; }
        public Star Star { get; set; }
        public Category Category { get; set; }
        
    }
}
