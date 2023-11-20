using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pic6.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
        public int DepartmentId { get; set; }
    }

}
