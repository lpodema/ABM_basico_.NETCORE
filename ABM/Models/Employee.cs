using System;
using ABM.Models;

namespace ABM
{

    public class Employee : Person
    {

        public DateTime? HiringDate { get; set; }

        public string Area { get; set; }

        public string Seniority { get; set; }


    }

}

