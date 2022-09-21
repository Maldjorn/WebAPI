using System.ComponentModel.DataAnnotations;

namespace CM.Customers.Entities
{
    public class Address
    {

        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Field is required"),MaxLength(100, ErrorMessage = "Max length should be less than 100")]
        public string AddressLine { get; set; }
        [MaxLength(100, ErrorMessage = "Max length should be less than 100")]
        public string AddressLine2 { get; set; }
        public int AddressType { get; set; }
        [MaxLength(50, ErrorMessage = "Max length should be less than 50")]
        public string City { get; set; }
        [MaxLength(6, ErrorMessage = "Max length should be less than 6")]
        public string PostalCode { get; set; }
        [MaxLength(20, ErrorMessage = "Max length should be less than 20")]
        public string State { get; set; }
        public string Country { get; set; }
    }
}
