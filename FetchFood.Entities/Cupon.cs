using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Entities
{
    internal class Cupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public float Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
