using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class ServiceDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Name_ar { get; set; }
        [Required]
        public string Logo { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Description_ar { get; set; }

        public virtual ICollection<StarDTO> Stars { get; set; }
    }
    public class GETServiceDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Name_ar { get; set; }
        [Required]
        public string Logo { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Description_ar { get; set; }

        public virtual ICollection<OnlyStarDTO> Stars { get; set; }
    }
}
