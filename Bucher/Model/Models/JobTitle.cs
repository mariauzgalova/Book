using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bucher.Model.Models
{
    public partial class JobTitle
    {
        public int IdJobtitle { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual Empoyees IdJobtitleNavigation { get; set; }
    }
}
