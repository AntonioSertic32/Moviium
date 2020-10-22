using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesCoreAPI.Models
{
    public class Records
    {
        [Key]
        public int RecordID { get; set; }
        public int Rate { get; set; }
        public int? MovieId { get; set; }
        public int? UserId { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual Users User { get; set; }
    }
}
