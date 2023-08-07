using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFC0re
{
    public partial class Data
    {
        public Guid Iddata { get; set; }
        public int? Period { get; set; }
        public int? CpuLoading { get; set; }
        public int? RamLoading { get; set; }
        public double? Rpc { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
