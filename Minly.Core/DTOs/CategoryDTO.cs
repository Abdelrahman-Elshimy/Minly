using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class BaseCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategoryDTO: BaseCategoryDTO
    {
        public virtual ICollection<StarDTO> Stars { get; set; }
    }
    public class GETCategoryDTO: BaseCategoryDTO
    {
        public virtual ICollection<OnlyStarDTO> Stars { get; set; }
    }
}
