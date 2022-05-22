using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class AddCarViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        public string ImageUrl { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        [RegularExpression(@"^[A-Z]{2}[\d]{4}[A-Z]{2}$", ErrorMessage = "Must be a valid plate")]
        public string PlateNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        public string Year { get; set; }
    }
}