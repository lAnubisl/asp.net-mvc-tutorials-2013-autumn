using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson02.Models
{
    public class Person
    {
        [Required]
        [DisplayName("First Name")]
        [RegularExpression("^[a-zA-Z-]+$", ErrorMessage = "{0} is not valid.")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "{0} should be {2} to {1} letters.")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}