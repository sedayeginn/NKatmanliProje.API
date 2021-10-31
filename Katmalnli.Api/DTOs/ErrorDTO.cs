using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katmalnli.Api.DTOs
{
    public class ErrorDTO
    {
        public ErrorDTO()
        {
            Errors = new List<string>();
        }
        public List<String> Errors { get; set; }
        public int Status { get; set; }
    }
}
