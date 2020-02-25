using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Loan_Comp.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Minimum Amount")]
        public double MinimumAmount { get; set; }
        public string Name { get; set; }
        public string Terms { get; set; }
        public int Rate { get; set; }
        [Required]
        public string LoanPurpose { get; set; }
        public string Link { get; set; }
        public double MaximumAmount { get; set; }

        [Required]
        public double Duration { get; set; }

        public int Count { get; set; }
        public int UniqueCount { get; set; }
    }

    public class Clicks
    {
        [Key]
        public int ClickId { get; set; }
        public string UserId { get; set; }

        public int CompanyId { get; set; }

    }

    public class Payment
    {
        [Key]
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Info
    {
        [Key]
        public int InfoId { get; set; }
        public string UserId { get; set; }
        public double Amount { get; set; }
        public double Duration { get; set; }
    }
}