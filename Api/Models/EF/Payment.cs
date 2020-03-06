namespace Api.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Key]
        public string UserId { get; set; }
    }
}
