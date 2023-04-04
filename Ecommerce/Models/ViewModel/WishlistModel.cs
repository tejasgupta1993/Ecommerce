using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.ViewModel
{
    public class WishlistModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductDetailsId { get; set; }
    }
    public class ShowWishlist
    {
        [Required]
        public int UserId { get; set; }
    }
}
