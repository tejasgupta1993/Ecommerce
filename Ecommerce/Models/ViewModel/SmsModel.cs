using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class SmsModel
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public string Message { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
