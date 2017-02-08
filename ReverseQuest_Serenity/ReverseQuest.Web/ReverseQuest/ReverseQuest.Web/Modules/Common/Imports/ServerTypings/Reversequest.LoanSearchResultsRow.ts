namespace ReverseQuest.Reversequest {
    export interface LoanSearchResultsRow {
        Loan_Skey?: number;
        Original_Loan_Number?: string;
        Fha_Case_Number?: string;
        Prior_Servicer_Loan_Number?: string;
        Investor_Loan_Number?: string;
        Loan_Status?: string;
        Loan_Sub_Status?: string;
        Borrower_First_Name?: string;
        Borrower_Last_Name?: string;
        Coborrower_First_Name?: string;
        Coborrower_Last_Name?: string;
        Borrower_Phone_Number?: string;
        Enbs_First_Name?: string;
        Enbs_Last_Name?: string;
        Property_Address1?: string;
        Property_Address2?: string;
        Property_City?: string;
        Property_County?: string;
        Property_State?: string;
        Property_ZipCode?: string;
        Servicer_Name?: string;
        Investor_Name?: string;
        Loan_Pool_Description?: string;
        Product_Type_Description?: string;
        Payment_Plan_Type_Description?: string;
        Arm_Type_Description?: string;
        Rate_Index_Type_Description?: string;
        Loan_Manager_Name?: string;
        Boarded_By?: string;
        Boarded_Date?: string;
        Boarding_Type_Description?: string;
        Credit_Type_Description?: string;
        Mers_Min_Number?: string;
        Loan_Sub_Status_Code?: string;
        Loan_Servicer_Skey?: number;
        Investor_Skey?: number;
        Loan_Pool_Skey?: number;
        Product_Type_Skey?: number;
        Payment_Plan_Type?: number;
        Arm_Type?: string;
        Rate_Index_Type_Skey?: number;
        Loan_Manager_Id?: string;
        Boarding_Type?: string;
        Credit_Type?: string;
        Row_Count?: number;
        Loan_Status_Code?: string;
        Filler?: string;
    }

    export namespace LoanSearchResultsRow {
        export const idProperty = 'Loan_Skey';
        export const nameProperty = 'Original_Loan_Number';
        export const localTextPrefix = 'Reversequest.LoanSearchResults';

        export namespace Fields {
            export declare const Loan_Skey: string;
            export declare const Original_Loan_Number: string;
            export declare const Fha_Case_Number: string;
            export declare const Prior_Servicer_Loan_Number: string;
            export declare const Investor_Loan_Number: string;
            export declare const Loan_Status: string;
            export declare const Loan_Sub_Status: string;
            export declare const Borrower_First_Name: string;
            export declare const Borrower_Last_Name: string;
            export declare const Coborrower_First_Name: string;
            export declare const Coborrower_Last_Name: string;
            export declare const Borrower_Phone_Number: string;
            export declare const Enbs_First_Name: string;
            export declare const Enbs_Last_Name: string;
            export declare const Property_Address1: string;
            export declare const Property_Address2: string;
            export declare const Property_City: string;
            export declare const Property_County: string;
            export declare const Property_State: string;
            export declare const Property_ZipCode: string;
            export declare const Servicer_Name: string;
            export declare const Investor_Name: string;
            export declare const Loan_Pool_Description: string;
            export declare const Product_Type_Description: string;
            export declare const Payment_Plan_Type_Description: string;
            export declare const Arm_Type_Description: string;
            export declare const Rate_Index_Type_Description: string;
            export declare const Loan_Manager_Name: string;
            export declare const Boarded_By: string;
            export declare const Boarded_Date: string;
            export declare const Boarding_Type_Description: string;
            export declare const Credit_Type_Description: string;
            export declare const Mers_Min_Number: string;
            export declare const Loan_Sub_Status_Code: string;
            export declare const Loan_Servicer_Skey: string;
            export declare const Investor_Skey: string;
            export declare const Loan_Pool_Skey: string;
            export declare const Product_Type_Skey: string;
            export declare const Payment_Plan_Type: string;
            export declare const Arm_Type: string;
            export declare const Rate_Index_Type_Skey: string;
            export declare const Loan_Manager_Id: string;
            export declare const Boarding_Type: string;
            export declare const Credit_Type: string;
            export declare const Row_Count: string;
            export declare const Loan_Status_Code: string;
            export declare const Filler: string;
        }

        ['Loan_Skey', 'Original_Loan_Number', 'Fha_Case_Number', 'Prior_Servicer_Loan_Number', 'Investor_Loan_Number', 'Loan_Status', 'Loan_Sub_Status', 'Borrower_First_Name', 'Borrower_Last_Name', 'Coborrower_First_Name', 'Coborrower_Last_Name', 'Borrower_Phone_Number', 'Enbs_First_Name', 'Enbs_Last_Name', 'Property_Address1', 'Property_Address2', 'Property_City', 'Property_County', 'Property_State', 'Property_ZipCode', 'Servicer_Name', 'Investor_Name', 'Loan_Pool_Description', 'Product_Type_Description', 'Payment_Plan_Type_Description', 'Arm_Type_Description', 'Rate_Index_Type_Description', 'Loan_Manager_Name', 'Boarded_By', 'Boarded_Date', 'Boarding_Type_Description', 'Credit_Type_Description', 'Mers_Min_Number', 'Loan_Sub_Status_Code', 'Loan_Servicer_Skey', 'Investor_Skey', 'Loan_Pool_Skey', 'Product_Type_Skey', 'Payment_Plan_Type', 'Arm_Type', 'Rate_Index_Type_Skey', 'Loan_Manager_Id', 'Boarding_Type', 'Credit_Type', 'Row_Count', 'Loan_Status_Code', 'Filler'].forEach(x => (<any>Fields)[x] = x);
    }
}

