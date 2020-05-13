using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ekspertiz.App_Classes
{
    public class AnasayfaValidate
    {
        [Required]
        [MaxLength(17)]
        [RegularExpression("(^[A-Za-z0-9]{17})|(^(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\\d{4,5})|([A-Z]{2})(\\d{3,4})|([A-Z]{3})(\\d{2,3})))$")]
        public string PlakaSasi { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}