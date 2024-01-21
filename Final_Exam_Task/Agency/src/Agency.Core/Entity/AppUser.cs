using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Entity
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength:50, MinimumLength =2)]
        [Required]
        public string FullName { get; set; }
    }
}
