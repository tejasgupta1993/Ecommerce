using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.ViewModel
{
    public class CategoryModelL2
    {
        [Required]
        public int CategoryL1Id { get; set; }
        [Required]
        public string CategoryL2Name { get; set; }
    }
}
