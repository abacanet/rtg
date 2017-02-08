
namespace ReverseQuest.Reversequest.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Reversequest.LoanSearchResults")]
    [BasedOnRow(typeof(Entities.LoanSearchResultsRow))]
    public class LoanSearchResultsColumns
    {
       
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Loan_Skey { get; set; }
        [EditLink]
        public String Original_Loan_Number { get; set; }
        public String Fha_Case_Number { get; set; }
        public String Prior_Servicer_Loan_Number { get; set; }
        public String Investor_Loan_Number { get; set; }
        public String Loan_Status { get; set; }
        public String Loan_Sub_Status { get; set; }
        public String Borrower_First_Name { get; set; }
        public String Borrower_Middle_Name { get; set; }
        public String Borrower_Last_Name { get; set; }
        public String Coborrower_First_Name { get; set; }
        //public String CoborrowerMiddleName { get; set; }
        public String Coborrower_Last_Name { get; set; }
        public String Borrower_Phone_Number { get; set; }
        public String Enbs_First_Name { get; set; }
        //public String EnbsMiddleName { get; set; }
        public String Enbs_Last_Name { get; set; }
        public String Property_Address1 { get; set; }
        public String Property_Address2 { get; set; }
        public String Property_City { get; set; }
        public String Property_County { get; set; }
        public String Property_State { get; set; }
        public String Property_Zipcode { get; set; }
        public String Servicer_Name { get; set; }
        public String Investor_Name { get; set; }
        public String Loan_Pool_Description { get; set; }
        public String Product_Type_Description { get; set; }
        public String Payment_Plan_Type_Description { get; set; }
        public String Arm_Type_Description { get; set; }
        public String Rate_Index_Type_Description { get; set; }
        public String Loan_Manager_Name { get; set; }
        public String Boarded_By { get; set; }
        public DateTime Boarded_Date { get; set; }
        public String Boarding_Type_Description { get; set; }
        public String Credit_Type_Description { get; set; }
        public String Mers_Min_Number { get; set; }
        
        public String Loan_Sub_Status_Code { get; set; }
        public Int32 Loan_Servicer_Skey { get; set; }
        public Int32 Investor_Skey { get; set; }
        public Int32 LoanPool_Skey { get; set; }
        public Int32 Product_Type_Skey { get; set; }
        public Int32 Payment_Plan_Type { get; set; }
        public String Arm_Type { get; set; }
        public Int32 Rate_Index_Type_Skey { get; set; }
        public String Loan_ManagerId { get; set; }
        public String Boarding_Type { get; set; }
        public String Credit_Type { get; set; }

        public String Loan_Status_Code { get; set; }
        public String Filler { get; set; }
    }
}