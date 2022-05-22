using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models
{
    public class Issue
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public bool IsFixed { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}