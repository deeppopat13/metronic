using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace metronic.Areas.Contact.Models
{
    public class ContactModel
    {
        public int? CountryID { get; set; }
        public int? ContactID { get; set; }

        public int CategoryID { get; set; }

        public int CityID { get; set; }

        public int StateID { get; set; }
        [Required]
        [DisplayName("Contact Name")]
        [StringLength(20, MinimumLength = 3)]

        public string? ContactName { get; set; }

        public string ContactMobile { get; set; }


        public string? ContactAddress { get; set; }


        public int ContactPincode { get; set; }
        [EmailAddress]

        public string? ContactEmail { get; set; }


        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }

        public string PhotoPath { get; set; }


    }
}
