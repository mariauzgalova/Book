using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bucher.Model.Models
{
    public partial class Empoyees
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Telefon { get; set; }

        public virtual JobTitle JobTitle { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {LastName}";
        }
    }
}
