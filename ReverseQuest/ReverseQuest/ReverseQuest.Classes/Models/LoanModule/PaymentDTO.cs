using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule
{
    public class PaymentDTO
    {
        public decimal? PaymentsRemain { get; set; }
        public long? PaymentStatusSkey { get; set; }
        public string PaymentStatusDescription { get; set; }
    }
}
