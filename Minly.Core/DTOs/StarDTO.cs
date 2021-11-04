using Minly.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class StarDTO: OnlyStarDTO
    {

        public virtual ICollection<CategoryDTO> Categories { get; set; }
        public virtual ICollection<ServiceDTO> Services { get; set; }
        public virtual ICollection<StarRateDTO> StarRates { get; set; }

    }
    public class OnlyStarDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Name_ar { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ResponseTime { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Description_ar { get; set; }

        [Required]
        public double Rate { get; set; }
    }
}
