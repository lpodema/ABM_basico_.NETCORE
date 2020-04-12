using System;
using System.ComponentModel.DataAnnotations;

namespace ABMFront.ViewModels
{
    public class EmployeeViewModel : PersonViewModel
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? HiringDate { get; set; }

        public string Area { get; set; }

        public string Seniority { get; set; }


    }

    public enum EnumArea { DevOps, Developer, QA, HelpDesk }

    public enum EnumSeniority { Trainee, Junior, SemiSenior, Senior }
}