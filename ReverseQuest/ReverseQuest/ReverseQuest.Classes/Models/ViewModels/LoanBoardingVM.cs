using CsvHelper;
using ReverseQuest.Classes.Models.LoanBoarding;
using ReverseQuest.Classes.Models.LoanModule;
using ReverseQuest.Classes.Models.Shared.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseQuest.Classes.Models.ViewModels
{
    public class LoanBoardingVM
    {
        public int BatchSkey { get; set; }
        public int Servicer { get; set; }
        public int Investor { get; set; }
        public int InvestorPool { get; set; }   //InvestorPool
        public int CollateralCategory { get; set; }
        public string BoardingType { get; set; }
        public int PriorServicer { get; set; }    
    }
}
