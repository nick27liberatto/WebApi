using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum ElementEnum
    {
        [Display(Name = "Inactive")]
        Inactive = 0,
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "Archived")]
        Archived = 2
    }
}
