using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanBoarding
{
    public class LoanBoardingDTO
    {
        public int Servicer { get; set; }
        public int Investor { get; set; }
        public int InvestorPool { get; set; }   //InvestorPool
        public string CollateralCategory { get; set; }
        public string BoardingType { get; set; }
        public string PriorServicer { get; set; }
        public List<LoanModule.LoanMasterDTO> Loans { get; set; }
    }
}
