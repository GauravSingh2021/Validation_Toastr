using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage =" *Enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = " *Enter your Salary")]
        public int Salary { get; set; }
        [Required(ErrorMessage = " *Enter your City")]
        public string City { get; set; }
    }
}
