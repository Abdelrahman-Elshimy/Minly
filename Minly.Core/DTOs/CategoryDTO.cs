using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StarDTO> Stars { get; set; }
    }
    public class GETCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OnlyStarDTO> Stars { get; set; }
    }
}
