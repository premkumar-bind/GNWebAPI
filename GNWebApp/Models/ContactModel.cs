using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GNWebApp.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [DisplayName("First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [DisplayName("Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Addess")]
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string State { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [DisplayName("Pin Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
    }
}