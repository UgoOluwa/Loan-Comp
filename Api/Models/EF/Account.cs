namespace Api.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [Key]
        public int Account_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Account_type { get; set; }

        [Required]
        [StringLength(50)]
        public string Account_Number { get; set; }

        public decimal Account_balance { get; set; }

        public int Customer_id { get; set; }

        public virtual customer_table customer_table { get; set; }
    }
}
