using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class Star
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Image { get; set; }
        public int ResponseTime { get; set; }
        public string Description { get; set; }
        public string Description_ar { get; set; }

        public double Rate { get; set; }

        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Service> Services { get; set; }
        public virtual IList<StarRate> StarRates { get; set; }

    }
}
