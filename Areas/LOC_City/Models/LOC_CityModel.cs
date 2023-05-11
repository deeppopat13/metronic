using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace metronic.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }

        public int? CountryID { get; set; }

        public int StateID { get; set; }
        [Required]
        [DisplayName("City Name")]
        [StringLength(20, MinimumLength = 3)]

        public string? CityName { get; set; }

        public int? CityCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }


    }
    public class LOC_CityDropDownModel
    {
        public int CityID { get; set; }

        public string CityName { get; set; }

    }
}


