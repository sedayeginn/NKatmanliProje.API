using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
