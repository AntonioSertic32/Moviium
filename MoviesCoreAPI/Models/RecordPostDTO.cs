using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCoreAPI.Models
{
    public class RecordPostDTO
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rate { get; set; }
    }
}
