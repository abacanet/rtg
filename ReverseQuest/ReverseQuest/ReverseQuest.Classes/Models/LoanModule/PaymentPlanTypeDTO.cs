using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanModule
{
    public class PaymentPlanTypeDTO
    {
        public long? Type { get; set; }
        public string PaymentPlanDescription { get; set; }
        public string HmbsPaymentOption { get; set; }
        public long? StatusSkey { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
