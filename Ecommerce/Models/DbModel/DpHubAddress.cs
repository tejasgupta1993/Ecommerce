using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Ecommerce.Models.DbModel
{
    public partial class DpHubAddress
    {
        public int Id { get; set; }
        public int DpHubId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Phone { get; set; }

        public virtual DpHub DpHub { get; set; }
    }
}
