using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minly.Core.DTOs
{
    public class CreateStarResponseDTO
    {
        public string Video { get; set; }
        public string Message { get; set; }
        public string Audio { get; set; }
        public int RequestStarId { get; set; }
    }
    public class StarResponseDTO: CreateStarResponseDTO
    {
        public int Id { get; set; }
        public RequestStar RequestStar { get; set; }
    }
}
