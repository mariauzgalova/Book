using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bucher.Model.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public int? Price { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? TimeIssue { get; set; }

        public int? ClientId { get; set; }
        public int? BookId { get; set; }
        public virtual Client Client { get; set; }
    }
}
