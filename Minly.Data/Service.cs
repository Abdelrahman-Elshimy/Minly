using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
        public string Logo { get; set; }

        public string Description { get; set; }
        public string Description_ar { get; set; }

        public virtual IList<Star> Stars { get; set; }
    }
}
