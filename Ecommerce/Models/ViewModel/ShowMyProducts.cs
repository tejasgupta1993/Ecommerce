using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.ViewModel
{
    public class ShowMyProducts
    {
        [Required]
        public int UserId { get; set; }
    }
}
