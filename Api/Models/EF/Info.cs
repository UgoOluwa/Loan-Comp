namespace Api.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Info
    {
        public int InfoId { get; set; }

        public string UserId { get; set; }

        public double Amount { get; set; }

        public double Duration { get; set; }
    }
}
