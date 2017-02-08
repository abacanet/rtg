using ReverseQuest.Classes.Models.LoanModule.LoanDetail;
using ReverseQuest.Classes.Models.Shared;
using ReverseQuest.Classes.Models.ViewModels;
using System;

namespace ReverseQuest.Classes.Models.LoanModule
{
    public class LoanDetailDTO
    {
        public LoanMasterDTO LoanMasterDTO { get; set; }
        public LoanRate LoanRatesDTO { get; set; } 
        public LoanServicerDTO LoanServicerDTO { get; set; }
        public LoanSubStatusDTO LoanSubStatusDTO { get; set; }
        public ReferenceProductTypeDTO ReferenceProductTypeDTO { get; set; }
        public PaymentPlanTypeDTO PaymentPlanTypeDTO { get; set; }
        public PaymentDTO PaymentDTO { get; set; }
        public SharedProperties ArmTypeDTO { get; set; }
        public SharedProperties RateIndexTypeDTO { get; set; }
        public SharedProperties RffGroupDTO { get; set; }
        public SharedProperties CountyClerkDTO { get; set; }

        public static LoanDetailVM convertModelToVM(LoanDetailDTO model)
        {
            if(model.LoanMasterDTO == null)
            {
                model.LoanMasterDTO = new LoanMasterDTO();
            }

            if(model.LoanRatesDTO == null)
            {
                model.LoanRatesDTO = new LoanRate();
            }

            if(model.LoanServicerDTO == null)
            {
                model.LoanServicerDTO = new LoanServicerDTO();
            }

            return new LoanDetailVM
            {
                LoanFiling = new LoanFiling
                {
                    HermitSKey = 0,
                    LoanManager = model.LoanMasterDTO.LoanManager,
                    MersMinNum = model.LoanMasterDTO.MersMinNumber,
                    PayOffDate = model.LoanMasterDTO.PayoffDate.GetValueOrDefault(),
                    Spoc = 0
                },
                LoanRate = model.LoanRatesDTO,
                LoanRecording = new LoanRecording
                {
                    AddtlPgFeeAmt = 0,
                    AdpCodeSectOfAcct = model.LoanMasterDTO.AdpCode,
                    BookNum = 0,
                    ClosingSignedDate = model.LoanMasterDTO.ClosingDate.GetValueOrDefault(),
                    FhaCaseNumAssignedDate = model.LoanMasterDTO.FhaCaseNumberAssignedDate.GetValueOrDefault(),
                    FirstPgRecFeeAmt = 0,
                    FundedDate = model.LoanMasterDTO.FundedDate.GetValueOrDefault(),
                    InstrumentNum = 0,
                    MersMinNum = model.LoanMasterDTO.MersMinNumber,
                    MicDate = DateTime.Now,
                    PageNum = 0,
                    RecordedDate = DateTime.Now,
                    StormSentDate = DateTime.Now
                },

                OtherInformation = new OtherInformation
                {
                    BoardedDate = DateTime.Now,
                    BoardingType = model.LoanMasterDTO.BoardingType,
                    CreditType = model.LoanMasterDTO.CreditType,
                    LoanChannelSkey = model.LoanMasterDTO.LoanChannelSkey,
                    LoanOriginatorSkey = model.LoanMasterDTO.LoanOriginatorSkey.GetValueOrDefault(),
                },
                PriorServicerInfo = new PriorServicerInfo
                {
                    LoanNumber = model.LoanMasterDTO.PriorServicerLoanNumber,
                    Name = model.LoanServicerDTO.LegalName,
                    Phone = model.LoanServicerDTO.MainPhoneNumber,
                    SubStatus = model.LoanMasterDTO.PriorServicerSubStatus
                }
            };
        }
    }
}