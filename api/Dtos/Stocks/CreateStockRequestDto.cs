using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Stocks
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength (10, ErrorMessage = " Symbol must be less than 10 Characters!")]
        public string Symbol { get; set; } = string.Empty;
        
        [Required]
        [MaxLength (50, ErrorMessage = " Company name must be less than 50 Characters!")]
        public string CompanyName { get; set; } = string.Empty;
        
        [Required]
        [Range (50, 1000000)]
        public decimal Purchased { get; set;}
        
        [Required]
        [Range (0.001, 100 )]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength (10 , ErrorMessage = "Industry must be less than 10 characters!")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range (1, 1000000000000000)]
        public long MarketCap { get; set; }
    } 
}