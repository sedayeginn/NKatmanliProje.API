using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alanı gereklidir.")]
        public string ProductName { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="{0} alanı {1}'den büyük bir alan olmalıdır.")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı {1}'den büyük bir alan olmalıdır.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
