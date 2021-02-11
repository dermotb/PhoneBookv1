using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBookv1.Models
{
    public class PhoneBookEntry
    {
        [Key]
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string EirCode { get; set; }

        public override string ToString()
        {
            return String.Format("Number: {0} -  Name: {1} - Address: {2}", Number, Name, Address);
        }
    }
}
