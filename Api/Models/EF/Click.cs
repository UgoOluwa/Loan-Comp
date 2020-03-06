namespace Api.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Click
    {
        public string UserId { get; set; }

        public int CompanyId { get; set; }

        public int ClickId { get; set; }
    }
}
