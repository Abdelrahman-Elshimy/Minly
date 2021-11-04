using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
