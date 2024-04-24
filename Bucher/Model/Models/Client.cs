using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bucher.Model.Models
{
    public partial class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public int? Telefon { get; set; }

        public virtual Orders IdClientNavigation { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {Lastname}";
        }

    }
}
