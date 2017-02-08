
namespace ReverseQuest.Reversequest.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("ReverseQuest"), DisplayName("Loan Search Results"), InstanceName("LoanSearchResults"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class LoanSearchResultsRow : Row, INameRow //IIdRow,
    {
       
        [DisplayName("Loan Skey"), Column("loan_skey")]
        public Int32? Loan_Skey
        {
            get { return Fields.Loan_Skey[this]; }
            set { Fields.Loan_Skey[this] = value; }
        }

        [DisplayName("Original Loan Number"), Column("original_loan_number"), Size(20), QuickSearch]
        public String Original_Loan_Number
        {
            get { return Fields.Original_Loan_Number[this]; }
            set { Fields.Original_Loan_Number[this] = value; }
        }

        [DisplayName("Fha Case Number"), Column("fha_case_number"), Size(20)]
        public String Fha_Case_Number
        {
            get { return Fields.Fha_Case_Number[this]; }
            set { Fields.Fha_Case_Number[this] = value; }
        }

        [DisplayName("Prior Servicer Loan Number"), Column("prior_servicer_loan_number"), Size(20)]
        public String Prior_Servicer_Loan_Number
        {
            get { return Fields.Prior_Servicer_Loan_Number[this]; }
            set { Fields.Prior_Servicer_Loan_Number[this] = value; }
        }

        [DisplayName("Investor Loan Number"), Column("investor_loan_number"), Size(20)]
        public String Investor_Loan_Number
        {
            get { return Fields.Investor_Loan_Number[this]; }
            set { Fields.Investor_Loan_Number[this] = value; }
        }

        [DisplayName("Loan Status"), Column("loan_status"), Size(40)]
        public String Loan_Status
        {
            get { return Fields.Loan_Status[this]; }
            set { Fields.Loan_Status[this] = value; }
        }

        [DisplayName("Loan Sub Status"), Column("loan_sub_status"), Size(40)]
        public String Loan_Sub_Status
        {
            get { return Fields.Loan_Sub_Status[this]; }
            set { Fields.Loan_Sub_Status[this] = value; }
        }

        [DisplayName("Borrower First Name"), Column("borrower_first_name"), Size(60)]
        public String Borrower_First_Name
        {
            get { return Fields.Borrower_First_Name[this]; }
            set { Fields.Borrower_First_Name[this] = value; }
        }

        //[DisplayName("Borrower Middle Name"), Column("borrower_middle_name"), Size(60)]
        //public String BorrowerMiddleName
        //{
        //    get { return Fields.BorrowerMiddleName[this]; }
        //    set { Fields.BorrowerMiddleName[this] = value; }
        //}

        [DisplayName("Borrower Last Name"), Column("borrower_last_name"), Size(60)]
        public String Borrower_Last_Name
        {
            get { return Fields.Borrower_Last_Name[this]; }
            set { Fields.Borrower_Last_Name[this] = value; }
        }

        [DisplayName("Coborrower First Name"), Column("coborrower_first_name"), Size(60)]
        public String Coborrower_First_Name
        {
            get { return Fields.Coborrower_First_Name[this]; }
            set { Fields.Coborrower_First_Name[this] = value; }
        }

        //[DisplayName("Coborrower Middle Name"), Column("coborrower_middle_name"), Size(60)]
        //public String CoborrowerMiddleName
        //{
        //    get { return Fields.CoborrowerMiddleName[this]; }
        //    set { Fields.CoborrowerMiddleName[this] = value; }
        //}

        [DisplayName("Coborrower Last Name"), Column("coborrower_last_name"), Size(60)]
        public String Coborrower_Last_Name
        {
            get { return Fields.Coborrower_Last_Name[this]; }
            set { Fields.Coborrower_Last_Name[this] = value; }
        }

        [DisplayName("Borrower Phone Number"), Column("borrower_phone_number"), Size(20)]
        public String Borrower_Phone_Number
        {
            get { return Fields.Borrower_Phone_Number[this]; }
            set { Fields.Borrower_Phone_Number[this] = value; }
        }

        [DisplayName("Enbs First Name"), Column("enbs_first_name"), Size(60)]
        public String Enbs_First_Name
        {
            get { return Fields.Enbs_First_Name[this]; }
            set { Fields.Enbs_First_Name[this] = value; }
        }

        //[DisplayName("Enbs Middle Name"), Column("enbs_middle_name"), Size(60)]
        //public String EnbsMiddleName
        //{
        //    get { return Fields.EnbsMiddleName[this]; }
        //    set { Fields.EnbsMiddleName[this] = value; }
        //}

        [DisplayName("Enbs Last Name"), Column("enbs_last_name"), Size(60)]
        public String Enbs_Last_Name
        {
            get { return Fields.Enbs_Last_Name[this]; }
            set { Fields.Enbs_Last_Name[this] = value; }
        }

        [DisplayName("Property Address1"), Column("property_address1"), Size(60)]
        public String Property_Address1
        {
            get { return Fields.Property_Address1[this]; }
            set { Fields.Property_Address1[this] = value; }
        }

        [DisplayName("Property Address2"), Column("property_address2"), Size(60)]
        public String Property_Address2
        {
            get { return Fields.Property_Address2[this]; }
            set { Fields.Property_Address2[this] = value; }
        }

        [DisplayName("Property City"), Column("property_city"), Size(50)]
        public String Property_City
        {
            get { return Fields.Property_City[this]; }
            set { Fields.Property_City[this] = value; }
        }

        [DisplayName("Property County"), Column("property_county"), Size(75)]
        public String Property_County
        {
            get { return Fields.Property_County[this]; }
            set { Fields.Property_County[this] = value; }
        }

        [DisplayName("Property State"), Column("property_state"), Size(2)]
        public String Property_State
        {
            get { return Fields.Property_State[this]; }
            set { Fields.Property_State[this] = value; }
        }

        [DisplayName("Property Zipcode"), Column("property_zipcode"), Size(15)]
        public String Property_ZipCode
        {
            get { return Fields.Property_Zipcode[this]; }
            set { Fields.Property_Zipcode[this] = value; }
        }

        [DisplayName("Servicer Name"), Column("servicer_name"), Size(80)]
        public String Servicer_Name
        {
            get { return Fields.Servicer_Name[this]; }
            set { Fields.Servicer_Name[this] = value; }
        }

        [DisplayName("Investor Name"), Column("investor_name"), Size(80)]
        public String Investor_Name
        {
            get { return Fields.Investor_Name[this]; }
            set { Fields.Investor_Name[this] = value; }
        }

        [DisplayName("Loan Pool Description"), Column("loan_pool_description"), Size(80)]
        public String Loan_Pool_Description
        {
            get { return Fields.Loan_Pool_Description[this]; }
            set { Fields.Loan_Pool_Description[this] = value; }
        }

        [DisplayName("Product Type Description"), Column("product_type_description"), Size(50)]
        public String Product_Type_Description
        {
            get { return Fields.Product_Type_Description[this]; }
            set { Fields.Product_Type_Description[this] = value; }
        }

        [DisplayName("Payment Plan Type Description"), Column("payment_plan_type_description"), Size(30)]
        public String Payment_Plan_Type_Description
        {
            get { return Fields.Payment_Plan_Type_Description[this]; }
            set { Fields.Payment_Plan_Type_Description[this] = value; }
        }

        [DisplayName("Arm Type Description"), Column("arm_type_description"), Size(40)]
        public String Arm_Type_Description
        {
            get { return Fields.Arm_Type_Description[this]; }
            set { Fields.Arm_Type_Description[this] = value; }
        }

        [DisplayName("Rate Index Type Description"), Column("rate_index_type_description"), Size(50)]
        public String Rate_Index_Type_Description
        {
            get { return Fields.Rate_Index_Type_Description[this]; }
            set { Fields.Rate_Index_Type_Description[this] = value; }
        }

        [DisplayName("Loan Manager Name"), Column("loan_manager_name"), Size(100)]
        public String Loan_Manager_Name
        {
            get { return Fields.Loan_Manager_Name[this]; }
            set { Fields.Loan_Manager_Name[this] = value; }
        }

        [DisplayName("Boarded By"), Column("boarded_by"), Size(50)]
        public String Boarded_By
        {
            get { return Fields.Boarded_By[this]; }
            set { Fields.Boarded_By[this] = value; }
        }

        [DisplayName("Boarded Date"), Column("boarded_date")]
        public DateTime? Boarded_Date
        {
            get { return Fields.Boarded_Date[this]; }
            set { Fields.Boarded_Date[this] = value; }
        }

        [DisplayName("Boarding Type Description"), Column("boarding_type_description"), Size(20)]
        public String Boarding_Type_Description
        {
            get { return Fields.Boarding_Type_Description[this]; }
            set { Fields.Boarding_Type_Description[this] = value; }
        }

        [DisplayName("Credit Type Description"), Column("credit_type_description"), Size(20)]
        public String Credit_Type_Description
        {
            get { return Fields.Credit_Type_Description[this]; }
            set { Fields.Credit_Type_Description[this] = value; }
        }

        [DisplayName("Mers Min Number"), Column("mers_min_number"), Size(20)]
        public String Mers_Min_Number
        {
            get { return Fields.Mers_Min_Number[this]; }
            set { Fields.Mers_Min_Number[this] = value; }
        }



        [DisplayName("Loan Sub Status Code"), Column("loan_sub_status_code"), Size(5)]
        public String Loan_Sub_Status_Code
        {
            get { return Fields.Loan_Sub_Status_Code[this]; }
            set { Fields.Loan_Sub_Status_Code[this] = value; }
        }

        [DisplayName("Loan Servicer Skey"), Column("loan_servicer_skey")]
        public Int32? Loan_Servicer_Skey
        {
            get { return Fields.Loan_Servicer_Skey[this]; }
            set { Fields.Loan_Servicer_Skey[this] = value; }
        }

        [DisplayName("Investor Skey"), Column("investor_skey")]
        public Int32? Investor_Skey
        {
            get { return Fields.Investor_Skey[this]; }
            set { Fields.Investor_Skey[this] = value; }
        }

        [DisplayName("Loan Pool Skey"), Column("loan_pool_skey")]
        public Int32? Loan_Pool_Skey
        {
            get { return Fields.Loan_Pool_Skey[this]; }
            set { Fields.Loan_Pool_Skey[this] = value; }
        }

        [DisplayName("Product Type Skey"), Column("product_type_skey")]
        public Int32? Product_Type_Skey
        {
            get { return Fields.Product_Type_Skey[this]; }
            set { Fields.Product_Type_Skey[this] = value; }
        }

        [DisplayName("Payment Plan Type"), Column("payment_plan_type")]
        public Int32? Payment_Plan_Type
        {
            get { return Fields.Payment_Plan_Type[this]; }
            set { Fields.Payment_Plan_Type[this] = value; }
        }

        [DisplayName("Arm Type"), Column("arm_type"), Size(1)]
        public String Arm_Type
        {
            get { return Fields.Arm_Type[this]; }
            set { Fields.Arm_Type[this] = value; }
        }

        [DisplayName("Rate Index Type Skey"), Column("rate_index_type_skey")]
        public Int32? Rate_Index_Type_Skey
        {
            get { return Fields.Rate_Index_Type_Skey[this]; }
            set { Fields.Rate_Index_Type_Skey[this] = value; }
        }

        [DisplayName("Loan Manager Id"), Column("loan_manager_id"), Size(50)]
        public String Loan_Manager_Id
        {
            get { return Fields.Loan_Manager_Id[this]; }
            set { Fields.Loan_Manager_Id[this] = value; }
        }

        [DisplayName("Boarding Type"), Column("boarding_type"), Size(1)]
        public String Boarding_Type
        {
            get { return Fields.Boarding_Type[this]; }
            set { Fields.Boarding_Type[this] = value; }
        }

        [DisplayName("Credit Type"), Column("credit_type"), Size(1)]
        public String Credit_Type
        {
            get { return Fields.Credit_Type[this]; }
            set { Fields.Credit_Type[this] = value; }
        }

        [DisplayName("Record Count"), Column("record_count"), Size(5)]
        public Int32? Record_Count
        {
            get { return Fields.Record_Count[this]; }
            set { Fields.Record_Count[this] = value; }
        }

        [DisplayName("Loan Status Code"), Column("loan_status_code"), Size(5)]
        public String Loan_Status_Code
        {
            get { return Fields.Loan_Status_Code[this]; }
            set { Fields.Loan_Status_Code[this] = value; }
        }

        [DisplayName("Filler"), Column("filler"), Size(1)]
        public String Filler
        {
            get { return Fields.Filler[this]; }
            set { Fields.Filler[this] = value; }
        }

        //IIdField IIdRow.IdField
        //{
        //    get { return Fields.; }
        //}

        StringField INameRow.NameField
        {
            get { return Fields.Original_Loan_Number; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public LoanSearchResultsRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
           
            public Int32Field Loan_Skey;
            public StringField Original_Loan_Number;
            public StringField Fha_Case_Number;
            public StringField Prior_Servicer_Loan_Number;
            public StringField Investor_Loan_Number;
            public StringField Loan_Status;
            public StringField Loan_Sub_Status;
            public StringField Borrower_First_Name;
            //public StringField BorrowerMiddleName;
            public StringField Borrower_Last_Name;
            public StringField Coborrower_First_Name;
            //public StringField CoborrowerMiddleName;
            public StringField Coborrower_Last_Name;
            public StringField Borrower_Phone_Number;
            public StringField Enbs_First_Name;
            //public StringField EnbsMiddleName;
            public StringField Enbs_Last_Name;
            public StringField Property_Address1;
            public StringField Property_Address2;
            public StringField Property_City;
            public StringField Property_County;
            public StringField Property_State;
            public StringField Property_Zipcode;
            public StringField Servicer_Name;
            public StringField Investor_Name;
            public StringField Loan_Pool_Description;
            public StringField Product_Type_Description;
            public StringField Payment_Plan_Type_Description;
            public StringField Arm_Type_Description;
            public StringField Rate_Index_Type_Description;
            public StringField Loan_Manager_Name;
            public StringField Boarded_By;
            public DateTimeField Boarded_Date;
            public StringField Boarding_Type_Description;
            public StringField Credit_Type_Description;
            public StringField Mers_Min_Number;
            public StringField Loan_Sub_Status_Code;
            public Int32Field Loan_Servicer_Skey;
            public Int32Field Investor_Skey;
            public Int32Field Loan_Pool_Skey;
            public Int32Field Product_Type_Skey;
            public Int32Field Payment_Plan_Type;
            public StringField Arm_Type;
            public Int32Field Rate_Index_Type_Skey;
            public StringField Loan_Manager_Id;
            public StringField Boarding_Type;
            public StringField Credit_Type;
            public Int32Field Record_Count;
            public StringField Loan_Status_Code;
            public StringField Filler;

            public RowFields()
                : base("[dbo].[LoanSearchResults]")
            {
                LocalTextPrefix = "Reversequest.LoanSearchResults";
            }
        }
    }
}
