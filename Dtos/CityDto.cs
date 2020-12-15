using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_Web_Api.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "სახელი აუცილებელი ველია")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "მხოლოდ ციფრების გამოყენება არ არის შესაძლებელი")]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
