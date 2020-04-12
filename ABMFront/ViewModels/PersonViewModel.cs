using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ABMFront.ViewModels
{
    public abstract class PersonViewModel
    {
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(8, ErrorMessage = "{0} length must be 8", MinimumLength = 8)]
        public string DNI { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastName { get; set; }

        public string Gender { get; set; }
    }

    public enum EnumGender { Female, Male, Other }
}