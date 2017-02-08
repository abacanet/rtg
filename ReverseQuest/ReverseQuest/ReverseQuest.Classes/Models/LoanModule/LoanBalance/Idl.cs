using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule.LoanBalance
{
    public class Idl
    {
        public long LoanSkey { get; set; }
        public decimal? CreditLineDisbursementAmount { get; set; }
        public decimal? InterestMipServiceFeeRepayAmount { get; set; }
        public decimal? LoanBalance { get; set; }
        public decimal? CurrentNet { get; set; }
        public decimal? CurrentGrossCreditLine { get; set; }
        public decimal? CurrentNetCreditLine { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? NetGrowthAmount { get; set; }
    }
}
