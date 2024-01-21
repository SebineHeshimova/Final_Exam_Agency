using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Entity
{
    public class Setting:BaseEntity
    {
        [StringLength(maximumLength:20)]
        [Required]
        public string Key { get; set; }
        [StringLength(maximumLength: 20)]
        [Required]
        public string Value { get; set; }
    }
}
