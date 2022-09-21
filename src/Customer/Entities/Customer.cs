using CM.Customers.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CM.Customers
{
    public class Customer
    {
        
        public int CustomerID { get; set; }
        [MaxLength(50,ErrorMessage = "The length can't be more than 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Field is required"),MaxLength(50, ErrorMessage = "The length can't be more than 50 characters")]
        public string LastName { get; set; }
        public  List<Address> AddressList { get; set; }
        [MaxLength(15,ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Notes { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
    }
}
