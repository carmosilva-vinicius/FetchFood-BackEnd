using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Entities
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public string CompleteName { get; set; }
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }
    }
}
