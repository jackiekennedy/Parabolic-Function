using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Valley.Models
{
    public class UserData
    {
        [Key]
        public int UserDataId { get; set; }
        public float RangeFrom { get; set; }
        public float RangeTo { get; set; }
        public float Step { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        public virtual IEnumerable<Point> Points { get; set; }
        
    }
}
