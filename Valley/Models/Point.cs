using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Valley.Models
{
    public class Point
    {
        [Key]
        public int PointId { get; set; }
        public float PointX { get; set; }
        public float PointY { get; set; }

        public int UserDateId { get; set; }
 
        public virtual UserData UserDate { get; set; }
    }
}
