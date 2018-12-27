using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAP.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeeClass
    {
        [Key]
        public int StudentID { get; set; }
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Phonenumber { get; set; }
        public string Email { get; set; }



    }
}
