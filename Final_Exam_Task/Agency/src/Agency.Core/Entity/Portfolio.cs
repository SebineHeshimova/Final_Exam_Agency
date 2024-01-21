using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Entity
{
    public class Portfolio:BaseEntity
    {
        [StringLength(maximumLength:50, MinimumLength =3)]
        [Required]
        public string Caption { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        [Required]
        public string Category { get; set; }
        [StringLength(maximumLength:100)]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
