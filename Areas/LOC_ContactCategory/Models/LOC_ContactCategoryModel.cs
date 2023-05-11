using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace metronic.Areas.LOC_ContactCategory.Models
{
    public class LOC_ContactCategoryModel
    {
        public int? CategoryID { get; set; }
        [Required]
        [DisplayName("Category")]
        [StringLength(20, MinimumLength = 3)]

        public string? Category { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }
    public class LOC_ContactCategoryDropDownModel
    {
        public int CategoryID { get; set; }

        public string Category { get; set; }

    }
}
