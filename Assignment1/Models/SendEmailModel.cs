using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class SendEmailModel
    {
        [Required, Display(Name = "Your name")]

        public string Fromname { get; set; }

        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]

        public string Message { get; set; }
        

    }
}