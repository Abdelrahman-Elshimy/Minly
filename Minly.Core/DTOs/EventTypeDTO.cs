using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class EventTypeBasicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_ar { get; set; }
    }
    public class EventTypeDTO
    {
        public virtual ICollection<EventDTO> Events { get; set; }
    }
}
