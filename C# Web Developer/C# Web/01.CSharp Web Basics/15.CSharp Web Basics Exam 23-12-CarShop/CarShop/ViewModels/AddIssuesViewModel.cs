using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class AddIssuesViewModel
    {
        public string CarId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} can't be null or whitespace")]
        [MinLength(5, ErrorMessage = "Min Length 5")]
        public string Description { get; set; }
    }
}