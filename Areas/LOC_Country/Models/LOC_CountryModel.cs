using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace metronic.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {

        public int? CountryID { get; set; }

        [Required]
        [DisplayName("Country Name")]
        [StringLength(20, MinimumLength = 3)]

        public string? CountryName { get; set; }


        public int CountryCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }


    }
    public class LOC_CountryDropDownModel
    {
        public int CountryID { get; set; }

        public string? CountryName { get; set; }

    }
}

