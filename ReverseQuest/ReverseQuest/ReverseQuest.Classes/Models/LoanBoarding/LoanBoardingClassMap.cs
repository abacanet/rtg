using CsvHelper.Configuration;
using ReverseQuest.Classes.Models.LoanModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.LoanBoarding
{
    public sealed class LoanBoardingClassMap : CsvClassMap<LoanMasterDTO>
    {
        public LoanBoardingClassMap()
        {
            Map(m => m.OriginalLoanNumber).Name("Loan #");
            Map(m => m.FhaCaseNumber).Name("FHA Case #");
        }
    }
}
