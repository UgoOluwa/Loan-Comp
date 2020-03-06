namespace Api.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyViewModel
    {
        public int Id { get; set; }

        public double MinimumAmount { get; set; }

        public string Name { get; set; }

        public string Terms { get; set; }

        public int Rate { get; set; }

        [Required]
        public string LoanPurpose { get; set; }

        public string Link { get; set; }

        public double MaximumAmount { get; set; }

        public double Duration { get; set; }

        public int Count { get; set; }

        public int UniqueCount { get; set; }
    }
}
